using InventoryManagement_FontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace InventoryManagement_FontEnd.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        public async Task<IActionResult> Index()
        {
            List<Models.CategoryModel> categoryList = new List<CategoryModel>();
        var ApiUrl = _configuration["ApiUrl"];

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiUrl+"Category/fetch/all"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categoryList = JsonConvert.DeserializeObject<List<CategoryModel>>(apiResponse);
                }
            }
            return View(categoryList);
        }

        public async Task<IActionResult> GetAllCategoryItem()
        {
            var ApiUrl = _configuration["ApiUrl"];

            List<CategoryItemResponsecs> categoryItemList = new List<CategoryItemResponsecs>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiUrl+"Category/fetch-all-categories/items"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categoryItemList = JsonConvert.DeserializeObject<List<CategoryItemResponsecs>>(apiResponse);
                }
            }
            return View(categoryItemList);
        }
        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
            
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryModel request)
        {
            try
            {
                var ApiUrl = _configuration["ApiUrl"];

                var responsemsg =new GenericResponse<string>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync(ApiUrl+"Category/create",request))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        responsemsg = JsonConvert.DeserializeObject<GenericResponse<string>>(apiResponse);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var ApiUrl = _configuration["ApiUrl"];

            var model = new CategoryModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiUrl+"Category/categorybyid?id="+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<CategoryModel>(apiResponse);
                }
            }
            return View(model);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryModel request)
        {
            try
            {
                var ApiUrl = _configuration["ApiUrl"];

                var responsemsg = new GenericResponse<string>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PutAsJsonAsync(ApiUrl+"Category/edit", request))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        responsemsg = JsonConvert.DeserializeObject<GenericResponse<string>>(apiResponse);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var ApiUrl = _configuration["ApiUrl"];

            var model = new CategoryModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiUrl+"Category/categorybyid?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<CategoryModel>(apiResponse);
                }
            }
            return View(model);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(CategoryModel request)
        {
            try
            {
                var ApiUrl = _configuration["ApiUrl"];

                var responsemsg = new GenericResponse<string>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(ApiUrl+"Category/delete?id=" + request.Id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        responsemsg = JsonConvert.DeserializeObject<GenericResponse<string>>(apiResponse);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
