using dotnet_aegis_test.Models;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System.Diagnostics;

namespace dotnet_aegis_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            var users = new List<UserViewModel>()
            {
                  new UserViewModel { Id = 1, FullName = "Alice Johnson", Email = "alice@example.com", Role = "Admin" },
                  new UserViewModel { Id = 2, FullName = "Bob Smith", Email = "bob@example.com", Role = "User" },
                  new UserViewModel { Id = 3, FullName = "Charlie Brown", Email = "charlie@example.com", Role = "Manager" },
                  new UserViewModel { Id = 4, FullName = "Diana Prince", Email = "diana@example.com", Role = "Editor" },
                  new UserViewModel { Id = 5, FullName = "Ethan Hunt", Email = "ethan@example.com", Role = "User" }
            };
            return View(users);
        }

        public IActionResult DownloadPdf()
        {
            var users = new List<UserViewModel>()
            {
                  new UserViewModel { Id = 1, FullName = "Alice Johnson", Email = "alice@example.com", Role = "Admin" },
                  new UserViewModel { Id = 2, FullName = "Bob Smith", Email = "bob@example.com", Role = "User" },
                  new UserViewModel { Id = 3, FullName = "Charlie Brown", Email = "charlie@example.com", Role = "Manager" },
                  new UserViewModel { Id = 4, FullName = "Diana Prince", Email = "diana@example.com", Role = "Editor" },
                  new UserViewModel { Id = 5, FullName = "Ethan Hunt", Email = "ethan@example.com", Role = "User" }
            };

            ViewData["users"] = users;

            return new ViewAsPdf(isPartialView: true, setBaseUrl: true, viewData: ViewData )
            {
                ContentDisposition = ContentDisposition.Attachment,
                FileName = "MyDocument.pdf"
            }; ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

