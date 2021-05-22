using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherDetailsClient.Models;

namespace WeatherDetailsClient.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string Baseurl = "http://localhost:8409/";
            var WeatherInfo = new List<Weather>();
            //HttpClient cl = new HttpClient();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Weather");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   

                    var ProdResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    WeatherInfo = JsonConvert.DeserializeObject<List<Weather>>(ProdResponse);

                }
                //returning the employee list to view  
                return View(WeatherInfo);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Weather w)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(w), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:8409/api/Weather", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<Weather>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]              
        public async Task<ActionResult> Details(string city)
        {
            Weather w = new Weather();
            
            using (var httpClient = new HttpClient())
            {
               
                using (var response = await httpClient.GetAsync("http://localhost:8409/api/Weather/"+city))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    w = JsonConvert.DeserializeObject<Weather>(apiResponse);
                }
            }
            return View(w);
        }
        [HttpGet]
        public ActionResult GetCity()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetCity(string city)
        {
            return RedirectToAction("Index");
        }


    }
}
