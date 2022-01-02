using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using WebApp.Models;
using System.Net.Http;
namespace WebApp.Controllers
{
    public class CustomerAttributeController : Controller
    {
        private string uri = "http://localhost:36936/api/CustomerAttribute/";
        private HttpClient httpClient = new HttpClient();
        public IActionResult Index(string code)
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<CustomerAttribute>>(
                                httpClient.GetStringAsync(uri).Result);
            if (string.IsNullOrEmpty(code))
            {
                return View(model);
            }
            else
            {
                model = model.Where(m=>m.attribute_values_code.ToLower().Contains(code.ToLower())).ToList();
                return View(model);
            }
            
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = JsonConvert.DeserializeObject<CustomerAttribute>(httpClient.GetStringAsync(uri+id).Result);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerAttribute newCust)
        {
            try
            {
                var model = httpClient.PostAsJsonAsync<CustomerAttribute>(uri, newCust).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = JsonConvert.DeserializeObject<CustomerAttribute>(httpClient.GetStringAsync(uri + id).Result);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CustomerAttribute editCust)
        {
            try
            {
                var model = httpClient.PutAsJsonAsync<CustomerAttribute>(uri, editCust).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }   
            catch (Exception e)
            {
                ViewBag.error = e.Message;
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var res = httpClient.DeleteAsync(uri + id).Result;
            return RedirectToAction("Index");
        }
    }
}
