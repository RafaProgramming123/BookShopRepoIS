using EShop.Domain.Domain;
using EShop.Domain.Identity;
using EShop.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Cryptography;

namespace EShop.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAppController : ControllerBase
    {

        private readonly IOrderService orderService;
        private readonly UserManager<EShopApplicationUser> userManager;

        public AdminAppController(IOrderService orderService, UserManager<EShopApplicationUser> userManager)
        {
            this.orderService = orderService;
            this.userManager = userManager;
        }


        [HttpGet("[action]")]
        public List<Order> GetAllOrders()
        {
            return this.orderService.GetAllOrders();
        }
        [HttpPost("[action]")]
        public Order GetDetails(BaseEntity id)
        {
            return this.orderService.GetDetailsForOrder(id);
        }



    }
}
