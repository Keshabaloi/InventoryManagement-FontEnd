using InventoryManagement_FontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace InventoryManagement_FontEnd.Controllers
{
    public class IteamController : Controller
    { 
         private readonly IConfiguration _configuration;
    public IteamController(IConfiguration configuration) 
        { 
        _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            var ApiUrl = _configuration["ApiUrl"];
            List<IteamModel> iteamList = new List<IteamModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiUrl+"Item/fetch-all"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    iteamList = JsonConvert.DeserializeObject<List<IteamModel>>(apiResponse);
                }
            }
            return View(iteamList);
        }

        // GET: IteamController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IteamController/Create
        public async Task<IActionResult> Create()
        {
            var ApiUrl = _configuration["ApiUrl"];
            List<Models.CategoryModel> categoryList = new List<CategoryModel>();
            var model = new IteamModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiUrl+"Category/fetch/all"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categoryList = JsonConvert.DeserializeObject<List<CategoryModel>>(apiResponse);
                    
                }
            }

            ViewBag.categoryList = categoryList;


            return View();
        }

        // POST: IteamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IteamModel request)
        {
            try
            {
                var ApiUrl = _configuration["ApiUrl"];
                var responsemsg = new GenericResponse<string>();
                var model = new ItemRequest();
                model.Name = request.Name;
                model.Description = request.Description;
                model.Price = request.Price;
                model.IsAvailable = request.IsAvailable;
                model.Quantity = request.Quantity;
                model.ThresholdQuantity = request.ThresholdQuantity;
                model.Categories = new List<Guid>()
            {
                   
                       request.CategoryId
                   
            };
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync(ApiUrl+"Item/create", model))
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

        // GET: IteamController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var ApiUrl = _configuration["ApiUrl"];
            List<Models.CategoryModel> categoryList = new List<CategoryModel>();
            var model = new IteamModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiUrl+"Category/fetch/all"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categoryList = JsonConvert.DeserializeObject<List<CategoryModel>>(apiResponse);

                }
            }

            ViewBag.categoryList = categoryList;
            var itembyid = new IteamModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiUrl+"Item/fetch-by-id?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    itembyid = JsonConvert.DeserializeObject<IteamModel>(apiResponse);
                }
            }
            if (itembyid.ItemCategories != null && itembyid.ItemCategories.Any())
                itembyid.CategoryId = itembyid.ItemCategories.FirstOrDefault().CategoryId;
           
            return View(itembyid);
        }

        // POST: IteamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IteamModel request)
        {
            try
            {
                var ApiUrl = _configuration["ApiUrl"];
                var responsemsg = new GenericResponse<string>();

                var model = new ItemRequest();
                model.Id = request.Id;
                model.Name = request.Name;
                model.Description = request.Description;
                model.Price = request.Price;
                model.IsAvailable = request.IsAvailable;
                model.Quantity = request.Quantity;
                model.ThresholdQuantity = request.ThresholdQuantity;
                model.Categories = new List<Guid>()
            {

                       request.CategoryId

            };
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PutAsJsonAsync(ApiUrl+"Item/update", model))
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

        // GET: IteamController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var ApiUrl = _configuration["ApiUrl"];
            List<Models.CategoryModel> categoryList = new List<CategoryModel>();
            var model = new IteamModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiUrl+"Category/fetch/all"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categoryList = JsonConvert.DeserializeObject<List<CategoryModel>>(apiResponse);

                }
            }

            ViewBag.categoryList = categoryList;
            var itembyid = new IteamModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiUrl+"Item/fetch-by-id?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    itembyid = JsonConvert.DeserializeObject<IteamModel>(apiResponse);
                }
            }
            if (itembyid.ItemCategories != null && itembyid.ItemCategories.Any())
                itembyid.CategoryId = itembyid.ItemCategories.FirstOrDefault().CategoryId;

            return View(itembyid);
        }

        // POST: IteamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(IteamModel request)
        {
            try
            {
                var ApiUrl = _configuration["ApiUrl"];
                var responsemsg = new GenericResponse<string>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PutAsync($"{ ApiUrl}Item/delete?id={request.Id}", null))
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
