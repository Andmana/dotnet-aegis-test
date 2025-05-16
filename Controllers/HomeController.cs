using dotnet_aegis_test.Models;
using dotnet_aegis_test.Repository;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System.Diagnostics;

namespace dotnet_aegis_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository userRepository;


        public HomeController(ILogger<HomeController> logger, IUserRepository _userRepository)
        {
            
            _logger = logger;
            userRepository = _userRepository;
        }

        // Create a list of users

        public IActionResult Index()
        {
            List<UserViewModel> users = userRepository.GetAllUsers();
            return View(users);
        }

        public IActionResult DownloadPdf()
        {
            List<UserViewModel> users = userRepository.GetAllUsers();
            ViewData["users"] = users;

            return new ViewAsPdf(isPartialView: true, setBaseUrl: true, viewData: ViewData )
            {
                ContentDisposition = ContentDisposition.Attachment,
                FileName = "MyDocument.pdf"
            }; ;
        }

        public IActionResult DownloadExcel()
        {

            List<UserViewModel> users = userRepository.GetAllUsers();
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Add a worksheet to the package
                var worksheet = package.Workbook.Worksheets.Add("Users");

                // Add title at the top (row 1)
                worksheet.Cells[1, 1].Value = "User List";

                // Merge cells for the title to span across all columns (1-4)
                worksheet.Cells[1, 1, 1, 4].Merge = true;

                // Style the title
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.Font.Size = 16;  // Increase the font size for the title
                worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);  // Background color for title

                // Add a blank row after the title (row 2) to create space
                worksheet.Row(2).Height = 10; // Adjust the row height to make more space

                // Add headers to the third row (row 3)
                worksheet.Cells[3, 1].Value = "ID";
                worksheet.Cells[3, 2].Value = "Full Name";
                worksheet.Cells[3, 3].Value = "Email";
                worksheet.Cells[3, 4].Value = "Role";

                // Set header style (bold, center alignment)
                using (var headerRange = worksheet.Cells[3, 1, 3, 4])
                {
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    headerRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);  // Gray background for headers
                }

                // Populate the worksheet with user data and apply borders
                for (int i = 0; i < users.Count; i++)
                {
                    var user = users[i];

                    // Insert user data into cells (starting from row 4 for the first data row)
                    worksheet.Cells[i + 4, 1].Value = user.Id;
                    worksheet.Cells[i + 4, 2].Value = user.FullName;
                    worksheet.Cells[i + 4, 3].Value = user.Email;
                    worksheet.Cells[i + 4, 4].Value = user.Role;

                    // Apply borders for each data cell
                    using (var cellRange = worksheet.Cells[i + 4, 1, i + 4, 4])
                    {
                        cellRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        cellRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        cellRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        cellRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    }
                }

                // Set column widths
                worksheet.Column(1).Width = 10; // ID column width
                worksheet.Column(2).Width = 25; // Full Name column width
                worksheet.Column(3).Width = 30; // Email column width
                worksheet.Column(4).Width = 15; // Role column width

                // Convert the package to a byte array
                var excelData = package.GetAsByteArray();

                // Define the content type and file name for the Excel file
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "UsersList.xlsx";

                // Return the Excel file as a download
                return File(excelData, contentType, fileName);
            }
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

