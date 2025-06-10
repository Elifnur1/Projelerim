1.  API Key Sistemi:

-   Her client için benzersiz bir API Key oluşturacağız

-   Bu API Key'leri veritabanında saklayacağız

-   Her API isteğinde bu key'i kontrol edeceğiz

1.  Katmanlı Güvenlik:

-   1. Katman: API Key kontrolü (client'ın geçerli olup olmadığı)

-   2. Katman: JWT kontrolü (kullanıcının yetkili olup olmadığı)

Öncelikle API Key'leri yönetmek için bir entity oluşturalım:

```csharp
using System.ComponentModel.DataAnnotations;

namespace EShop.Entity.Concrete
{
    public class ApiClient
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        
        [Required]
        [MaxLength(32)]
        public string ApiKey { get; set; } = null!;
        
        public string? Description { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? LastUsedAt { get; set; }
        
        public int RequestCount { get; set; }
    }
```

Şimdi bu entity'i DbContext'e ekleyelim:

```csharp
// ... existing code ...
        public DbSet<ApiClient> ApiClients { get; set; }
// ... existing code ...
```

Şimdi API Key kontrolü için bir middleware oluşturalım:
```csharp
using EShop.Data.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EShop.API.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string API_KEY_HEADER = "X-Api-Key";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, EShopDbContext dbContext)
        {
            if (!context.Request.Headers.TryGetValue(API_KEY_HEADER, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsJsonAsync(new { message = "API Key eksik!" });
                return;
            }

            var apiClient = await dbContext.ApiClients
                .FirstOrDefaultAsync(x => x.ApiKey == extractedApiKey && x.IsActive);

            if (apiClient == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsJsonAsync(new { message = "Geçersiz API Key!" });
                return;
            }

            // API kullanım istatistiklerini güncelle
            apiClient.LastUsedAt = DateTime.UtcNow;
            apiClient.RequestCount++;
            await dbContext.SaveChangesAsync();

            await _next(context);
        }
    }
```

API Key yönetimi için bir servis oluşturalım:

```csharp
using EShop.Entity.Concrete;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Abstract
{
    public interface IApiClientService
    {
        Task<ResponseDto<ApiClient>> CreateApiClientAsync(string name, string? description = null);
        Task<ResponseDto<ApiClient>> GetApiClientByKeyAsync(string apiKey);
        Task<ResponseDto<List<ApiClient>>> GetAllApiClientsAsync();
        Task<ResponseDto<NoContent>> DeactivateApiClientAsync(string apiKey);
        Task<ResponseDto<NoContent>> ActivateApiClientAsync(string apiKey);
    }
}
```

Şimdi bu interface'in implementasyonunu yapalım:

```csharp
using System.Security.Cryptography;
using EShop.Data.Abstract;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Concrete
{
    public class ApiClientManager : IApiClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApiClientManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<ApiClient>> CreateApiClientAsync(string name, string? description = null)
        {
            try
            {
                var apiKey = GenerateApiKey();
                var apiClient = new ApiClient
                {
                    Name = name,
                    ApiKey = apiKey,
                    Description = description
                };

                await _unitOfWork.GetRepository<ApiClient>().AddAsync(apiClient);
                await _unitOfWork.SaveAsync();

                return ResponseDto<ApiClient>.Success(apiClient, StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return ResponseDto<ApiClient>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<ApiClient>> GetApiClientByKeyAsync(string apiKey)
        {
            try
            {
                var apiClient = await _unitOfWork.GetRepository<ApiClient>()
                    .GetAsync(x => x.ApiKey == apiKey);

                if (apiClient == null)
                {
                    return ResponseDto<ApiClient>.Fail("API Client bulunamadı!", StatusCodes.Status404NotFound);
                }

                return ResponseDto<ApiClient>.Success(apiClient, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<ApiClient>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<List<ApiClient>>> GetAllApiClientsAsync()
        {
            try
            {
                var apiClients = await _unitOfWork.GetRepository<ApiClient>()
                    .GetAllAsync();

                return ResponseDto<List<ApiClient>>.Success(apiClients.ToList(), StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<List<ApiClient>>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> DeactivateApiClientAsync(string apiKey)
        {
            try
            {
                var apiClient = await _unitOfWork.GetRepository<ApiClient>()
                    .GetAsync(x => x.ApiKey == apiKey);

                if (apiClient == null)
                {
                    return ResponseDto<NoContent>.Fail("API Client bulunamadı!", StatusCodes.Status404NotFound);
                }

                apiClient.IsActive = false;
                await _unitOfWork.SaveAsync();

                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> ActivateApiClientAsync(string apiKey)
        {
            try
            {
                var apiClient = await _unitOfWork.GetRepository<ApiClient>()
                    .GetAsync(x => x.ApiKey == apiKey);

                if (apiClient == null)
                {
                    return ResponseDto<NoContent>.Fail("API Client bulunamadı!", StatusCodes.Status404NotFound);
                }

                apiClient.IsActive = true;
                await _unitOfWork.SaveAsync();

                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        private string GenerateApiKey()
        {
            var key = new byte[16];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(key);
                return Convert.ToBase64String(key).Replace("/", "_").Replace("+", "-").Replace("=", "");
            }
        }
    }
}
```

API Client'ları yönetmek için bir controller oluşturalım:

```csharp
using EShop.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")] // Sadece admin kullanıcılar API client'ları yönetebilir
    public class ApiClientController : ControllerBase
    {
        private readonly IApiClientService _apiClientService;

        public ApiClientController(IApiClientService apiClientService)
        {
            _apiClientService = apiClientService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateApiClientRequest request)
        {
            var result = await _apiClientService.CreateApiClientAsync(request.Name, request.Description);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _apiClientService.GetAllApiClientsAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{apiKey}")]
        public async Task<IActionResult> GetByKey(string apiKey)
        {
            var result = await _apiClientService.GetApiClientByKeyAsync(apiKey);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("{apiKey}/deactivate")]
        public async Task<IActionResult> Deactivate(string apiKey)
        {
            var result = await _apiClientService.DeactivateApiClientAsync(apiKey);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("{apiKey}/activate")]
        public async Task<IActionResult> Activate(string apiKey)
        {
            var result = await _apiClientService.ActivateApiClientAsync(apiKey);
            return StatusCode(result.StatusCode, result);
        }
    }

    public class CreateApiClientRequest
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
```

Son olarak, Program.cs'de gerekli servisleri ve middleware'i ekleyelim:

```csharp
// ... existing code ...

builder.Services.AddScoped<IApiClientService, ApiClientManager>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

// API Key middleware'ini authentication'dan önce ekleyin
app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthentication();
// ... existing code ...
```

şimdi migration yapalım.

Şimdi sistemimiz hazır. Size API Key korumasının nasıl çalıştığını ve nasıl test edebileceğimizi anlatayım:

1.  API Key Oluşturma:

-   Öncelikle bir API Key oluşturmamız gerekiyor. Bunu sadece Admin rolündeki kullanıcılar yapabilir.

-   Swagger veya Postman üzerinden şu endpoint'i kullanabilirsiniz:
```text
     POST /api/ApiClient
     {
         "name": "MVC Client",
         "description": "Frontend MVC uygulaması için API key"
     }
```

-   Bu isteği yaparken Admin kullanıcısının JWT token'ını Authorization header'ında göndermeniz gerekiyor.

2.  API Key Kullanımı:

-   Oluşturulan API Key'i tüm isteklerde X-Api-Key header'ı ile göndermeniz gerekiyor.
```text
     X-Api-Key: sizin_api_keyiniz
```

3.  MVC Tarafında Yapılması Gerekenler:

-   MVC projesinde HttpClientService'de her isteğe API Key'i eklemeliyiz.

-   Ayrıca appsettings.json'a API Key'i eklememiz gerekiyor.

Önce MVC tarafında appsettings.json'a API Key için bir alan ekleyelim:

```json
// ... existing code ...
  "ApiSettings": {
    "BaseUri": "http://localhost:5210/api/",
    "ApiKey": "henüz_api_key_oluşturulmadı"
  }
// ... existing code ...
```

Şimdi MVC tarafında ApiSettings sınıfımızı güncelleyelim:
```csharp
namespace EShop.MVC.Configurations
{
    public class ApiSettings
    {
        public string BaseUri { get; set; } = null!;
        public string ApiKey { get; set; } = null!;
    }
}
```

Şimdi HttpClientService'i güncelleyelim:

```csharp
using System.Text;
using System.Text.Json;
using EShop.MVC.Configurations;
using Microsoft.Extensions.Options;

namespace EShop.MVC.Services.Concrete
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public HttpClientService(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;
            _httpClient.BaseAddress = new Uri(_apiSettings.BaseUrl);
        }

        public async Task<TResponse> GetAsync<TResponse>(string endpoint)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
                request.Headers.Add("X-Api-Key", _apiSettings.ApiKey);

                var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Status: {response.StatusCode}, Message: {responseContent}");
                }

                var result = JsonSerializer.Deserialize<TResponse>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest request)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(request);
                using var httpRequest = new HttpRequestMessage(HttpMethod.Post, endpoint);
                httpRequest.Headers.Add("X-Api-Key", _apiSettings.ApiKey);
                httpRequest.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(httpRequest);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Status: {response.StatusCode}, Message: {responseContent}");
                }

                var result = JsonSerializer.Deserialize<TResponse>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest request)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(request);
                using var httpRequest = new HttpRequestMessage(HttpMethod.Put, endpoint);
                httpRequest.Headers.Add("X-Api-Key", _apiSettings.ApiKey);
                httpRequest.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(httpRequest);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Status: {response.StatusCode}, Message: {responseContent}");
                }

                var result = JsonSerializer.Deserialize<TResponse>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TResponse> DeleteAsync<TResponse>(string endpoint)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Delete, endpoint);
                request.Headers.Add("X-Api-Key", _apiSettings.ApiKey);

                var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Status: {response.StatusCode}, Message: {responseContent}");
                }

                var result = JsonSerializer.Deserialize<TResponse>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
```

Son olarak MVC projesinin Program.cs dosyasında ApiSettings'i configure edelim:
```csharp
// ... existing code ...
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddHttpClient<HttpClientService>(client =>
{
    var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();
    client.BaseAddress = new Uri(apiSettings!.BaseUrl);
});
// ... existing code ...
```


Şimdi test etmek için şu adımları izleyelim:

1.  Önce API projesini çalıştırın ve Admin kullanıcısı ile giriş yapın.
```text
POST http://localhost:5210/api/ApiClient
Authorization: Bearer {admin_jwt_token}
Content-Type: application/json

{
    "name": "MVC Client",
    "description": "Frontend MVC uygulaması için API key"
}
```

2.  Dönen yanıtta bir API Key alacaksınız. Bu API Key'i MVC projesinin appsettings.json dosyasındaki ApiSettings:ApiKey değerine yapıştırın.

3.  MVC uygulamasını yeniden başlatın.

Artık MVC uygulamanız API'ye her istek gönderdiğinde otomatik olarak API Key de gönderilecek ve API tarafında doğrulanacak. Eğer API Key geçersiz veya eksikse, istek 401 Unauthorized hatası ile reddedilecek.