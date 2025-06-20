using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project08_PortfolioApp.Areas.Admin.Models;
using Project08_PortfolioApp.Models;

namespace Project08_PortfolioApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly string _folderName;
        public ProjectController(IWebHostEnvironment webHostEnvironment)
        {
            _folderName = webHostEnvironment.WebRootPath + "/ui/img/projects";
        }
        public async Task<ActionResult> Index()
        {
            //Bağlantıyı hazırlıyoruz
            var connectionString = "Server=SINIF115\\SQLEXPRESS;Database=PortfolioDb;User=sa;Password=Qwe123.,;TrustServerCertificate=true";
            var connection = new SqlConnection(connectionString);

            //Proje listesini çekiyoruz
            var queryProjects = "select * from Projects";
            var projects = await connection.QueryAsync<Project>(queryProjects);

            return View(projects);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            AddProjectViewModel model = new()
            {
                CategoryList = await GetCategoryList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(AddProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Burada öncelikle resim yükleme işlemi yapılır. İlerde göreceğiz.
                //Şimdilik yüklendiğini varsayarak ImageUrl'e varsayılan bir resmin url bilgisini atayacağız.
                //GEÇİCİ OLARAK RESİM YÜKLEME OPERASYONU
                if (model.Image == null)
                {
                    model.CategoryList = await GetCategoryList();
                    return View(model);
                }
                if (model.Image.Length == 0)
                {
                    model.CategoryList = await GetCategoryList();
                    return View(model);
                }
                string[] correctExtensions = [".png", ".jpg", ".jpeg"];
                string fileExtension = Path.GetExtension(model.Image.FileName).ToLower();
                if (!correctExtensions.Contains(fileExtension))
                {
                    model.CategoryList = await GetCategoryList();
                    return View(model);
                }
                //a1e6d3fa-30c6-4fe9-83c3-0751769c071e.png
                string imageFileName = $"{Guid.NewGuid()}{fileExtension}";
                string target = _folderName + "/" + imageFileName;
                await using (var stream = new FileStream(target, FileMode.Create))
                {
                    await stream.CopyToAsync(stream);
                }

                model.ImageUrl = "http://localhost:5100/ui/img/projects/" + imageFileName;
                var query = @"
                    INSERT INTO Projects(Name,Description,CategoryId,GithubUrl,IsActive,ImageUrl)
                    VALUES (@Name,@Description,@CategoryId,@GithubUrl,@IsActive,@ImageUrl)
                ";
                var connectionString = "Server=localhost,1433;Database=PortfolioDb;User=sa;Password=Qwe123.,;TrustServerCertificate=true";
                var connection = new SqlConnection(connectionString);
                await connection.ExecuteAsync(query, model);
                return RedirectToAction("Index");
            }
            model.CategoryList = await GetCategoryList();
            return View(model);
        }

        [NonAction]
        private async Task<List<SelectListItem>> GetCategoryList()
        {
            //Bağlantıyı hazırlıyoruz
            var connectionString = "Server=localhost,1433;Database=PortfolioDb;User=sa;Password=Qwe123.,;TrustServerCertificate=true";
            var connection = new SqlConnection(connectionString);

            //Kategori listesini çekiyoruz
            var queryCategories = "select * from Categories";
            var categories = await connection.QueryAsync<Category>(queryCategories);
            List<SelectListItem> result = [];
            foreach (var category in categories)
            {
                result.Add(new SelectListItem
                {
                    Text = category.Name,
                    Value = category.Id.ToString()
                });
            }
            return result;
        }
    }
}
