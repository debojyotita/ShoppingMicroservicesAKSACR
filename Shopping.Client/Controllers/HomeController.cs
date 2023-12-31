using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping.Client.Data;
using Shopping.Client.Models;
using System.Diagnostics;

namespace Shopping.Client.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger,IHttpClientFactory httpClientFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient = httpClientFactory.CreateClient("ShoppingApiClient") ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

       
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/product/getallproducts");
            var content = await response.Content.ReadAsStringAsync();
            return View(JsonConvert.DeserializeObject<IEnumerable<Product>>(await response.Content.ReadAsStringAsync()));
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