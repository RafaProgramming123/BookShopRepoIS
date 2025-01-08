using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportUsers(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["Error"] = "Please upload a valid file.";
                return RedirectToAction("Index");
            }

            // Define the upload directory and ensure it exists
            string uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "files");
            string pathToUpload = Path.Combine(uploadDirectory, file.FileName);

            try
            {
                // Ensure the directory exists
                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }

                // Save the uploaded file
                using (FileStream fileStream = new FileStream(pathToUpload, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                // Extract users from the file
                List<User> users = getAllUsersFromFile(file.FileName);

                // Prepare and send the HTTP request
                using (HttpClient client = new HttpClient())
                {
                    string url = "http://localhost:5054/api/AdminApp/ImportAllUsers";
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(users), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync(url, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsAsync<bool>().Result;
                        if (result)
                        {
                            TempData["Success"] = "Users imported successfully!";
                        }
                        else
                        {
                            TempData["Error"] = "Failed to import users.";
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Error communicating with the API.";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"An error occurred: {ex.Message}";
            }
            finally
            {
                // Cleanup the uploaded file
                if (System.IO.File.Exists(pathToUpload))
                {
                    System.IO.File.Delete(pathToUpload);
                }
            }

            return RedirectToAction("Index");
        }


        private List<User> getAllUsersFromFile(string fileName)
        {
            List<User> users = new List<User>();
            string filePath = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        users.Add(new Models.User
                        {
                            Email = reader.GetValue(0).ToString(),
                            Password = reader.GetValue(1).ToString(),
                            ConfirmPassword = reader.GetValue(2).ToString()
                        });
                    }

                }
            }
            return users;

        }
    }
}

