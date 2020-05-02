using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ffhs_nmt2_translator_ui.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading;
using System.Net.Http;
using System.Text;

namespace ffhs_nmt2_translator_ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration Configuration;

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Translate([FromBody]TranslationRequest data)
        {
            var apiHost = Configuration["ApiHost"];

            var translationHttpMessage = await PostToApi(data, apiHost);
            var response = await translationHttpMessage.Content.ReadAsAsync<TranslationResponse>();
            return Json(response);
        }

        private static async Task<HttpResponseMessage> PostToApi(TranslationRequest content, String apiUrl)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, apiUrl))
            {
                var json = JsonConvert.SerializeObject(content, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                    return response.EnsureSuccessStatusCode();
                }
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
