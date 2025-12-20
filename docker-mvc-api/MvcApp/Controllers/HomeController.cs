using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeController(
        ILogger<HomeController> logger,
        IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

//  public async Task<IActionResult> Index()
// {
//     var client = _httpClientFactory.CreateClient("ApiClient");

//     string baseUrl = client.BaseAddress?.ToString() ?? "BASE_URL_NULL";
//     string response;

//     try
//     {
//         response = await client.GetStringAsync("/users");
//     }
//     catch (Exception ex)
//     {
//         response = "ERROR: " + ex.Message;
//     }

//     return Content(
//         $"BaseAddress:\n{baseUrl}\n\nResponse from API:\n{response}",
//         "text/plain"
//     );
// }
public async Task<IActionResult> Index()
{
    var client = _httpClientFactory.CreateClient("ApiClient");
    var response = await client.GetStringAsync("/users");

    ViewBag.UsersJson = response;
    return View();
}



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
