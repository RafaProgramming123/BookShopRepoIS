using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Text;
using WebApplication1.Models;

using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using GemBox.Document;
using QuestPDF.Fluent;
namespace WebApplication1.Controllers;

using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


    public class OrderController : Controller
{

    private readonly IHostEnvironment _hostEnvironment;
    public OrderController(IHostEnvironment hostEnvironment) {
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        _hostEnvironment = hostEnvironment;
    }

    public IActionResult Index()
    {
        HttpClient client = new HttpClient();
        string URL = "http://localhost:5054/api/AdminApp/GetAllOrders";
        HttpResponseMessage response = client.GetAsync(URL).Result;
        var data = response.Content.ReadAsAsync<List<Order>>().Result;
        return View(data);
    }
    public IActionResult Details(string id)
    {
        HttpClient client = new HttpClient();
        //added in next aud
        string URL = "http://localhost:5054/api/AdminApp/GetDetails";
        var model = new
        {
            Id = id
        };
        HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        HttpResponseMessage response = client.PostAsync(URL, content).Result;
        var result = response.Content.ReadAsAsync<Order>().Result;
        return View(result);
    }



    public FileContentResult CreateInvoice(string id)
    {
        // Initialize HttpClient
        HttpClient client = new HttpClient();

        // API endpoint to fetch order details
        string URL = "http://localhost:5054/api/AdminApp/GetDetails";

        // Prepare the request payload
        var model = new { Id = id };
        HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

        // Send the request and get the response
        HttpResponseMessage response = client.PostAsync(URL, content).Result;

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to retrieve order details.");
        }

        // Deserialize the response into the Order model
        Order result = response.Content.ReadAsAsync<Order>().Result;

        var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Invoice.docx");




        var document = DocumentModel.Load(templatePath);

        // Replace placeholders with dynamic data
        document.Content.Replace("{{OrderNumber}}", result.Id.ToString());
        document.Content.Replace("{{CustomerName}}", $"{result.User.FirstName} {result.User.LastName}");
        document.Content.Replace("{{Address}}", result.User.Address ?? "N/A");

        // Generate the book list and calculate the total price
        StringBuilder sb = new StringBuilder();
        decimal totalPrice = 0;

        sb.AppendLine("Book Title       | Quantity | Price  | Total");
        sb.AppendLine("-------------------------------------------------");

        foreach (var bookInOrder in result.bookInOrders)
        {
            var book = bookInOrder.Book;
            var total = bookInOrder.Quantity * (decimal)book.Price;

            // Append book details to the product list
            sb.AppendLine(
                $"{book.Title.PadRight(15)} | {bookInOrder.Quantity.ToString().PadRight(8)} | {book.Price.ToString("C").PadRight(8)} | {total.ToString("C")}"
            );

            totalPrice += total;
        }

        document.Content.Replace("{{BookList}}", sb.ToString());
        document.Content.Replace("{{TotalPrice}}", $"{totalPrice:C}");

        // Generate PDF and return it as a response
        using var stream = new MemoryStream();
        document.Save(stream, new PdfSaveOptions());
        return File(stream.ToArray(), new PdfSaveOptions().ContentType, $"Invoice_{result.Id}.pdf");
    }






}



