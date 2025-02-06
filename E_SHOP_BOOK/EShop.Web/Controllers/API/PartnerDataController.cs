using EShop.Domain.Domain;
using EShop.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EShop.Web.Controllers.API
{
 
        public class PartnerDataController : Controller
        {
            private readonly IHttpClientFactory _httpClientFactory;

            public PartnerDataController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            public async Task<IActionResult> Index()
            {
                var client = _httpClientFactory.CreateClient();

                // URLs of the external APIs
                var eventsUrl = "https://eventmanagementsystem2025.azurewebsites.net/Api/Admin/GetAllEvents";
                var scheduledEventsUrl = "https://eventmanagementsystem2025.azurewebsites.net/api/admin/getallScheduledEvents";

                // Call the endpoints
                var eventsJson = await client.GetStringAsync(eventsUrl);
                var scheduledEventsJson = await client.GetStringAsync(scheduledEventsUrl);

                // Deserialize the JSON into our model classes
                var eventsData = JsonConvert.DeserializeObject<List<PartnerEvent>>(eventsJson) ?? new List<PartnerEvent>();
                var scheduledEventsData = JsonConvert.DeserializeObject<List<ScheduledEvent>>(scheduledEventsJson) ?? new List<ScheduledEvent>();

                // (Optional) Apply any minimal transformation or cleaning of the data here

                var viewModel = new PartnerEventsViewModel
                {
                    Events = eventsData,
                    ScheduledEvents = scheduledEventsData
                };

                return View(viewModel);
            }
        }
    }

