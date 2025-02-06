using EShop.Domain.Domain;
using EShop.Domain.DTO;
using EShop.Domain.Identity;
using EShop.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Cryptography;
using Newtonsoft.Json;
using System.Text;

namespace EShop.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAppController : ControllerBase
    {

        private readonly IOrderService orderService;
        private readonly UserManager<EShopApplicationUser> userManager;
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;

        public AdminAppController(IOrderService orderService,IAuthorService authorService,IBookService bookService ,UserManager<EShopApplicationUser> userManager)
        {
            this.orderService = orderService;
            this.userManager = userManager;
            this.bookService = bookService;
            this.authorService=authorService;
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

        [HttpGet("[action]")]
        public List<Book> getAllBooks()
        {
            return this.bookService.GetAllBooks();
        }

        [HttpGet("[action]")]
        public List<Author> getAllAuthors()
        {
            return this.authorService.GetAllAuthors();  
        }



        [HttpGet("[action]")]
        public Book getBookDetails(Guid id)
        {
            return this.bookService.GetDetailsForBook(id);
        }

        [HttpGet("[action]")]
        public Author getDetailsForAuthor(Guid id)
        {
            return this.authorService.GetDetailsForAuthor(id);
        }




        [HttpPost("[action]")]
        public async Task<bool> ImportAllUsers(List<UserRegistraionDto> model)
        {
            bool status = true;

            foreach (var item in model)
            {
                try
                {
                    var user = new EShopApplicationUser
                    {
                        UserName = item.Email,
                        NormalizedUserName = item.Email.ToUpper(),
                        Email = item.Email,
                        EmailConfirmed = true,
                        ShoppingCart = new ShoppingCart()
                    };

                    var result = await userManager.CreateAsync(user, item.Password);

                    if (!result.Succeeded)
                    {
                        status = false;
                       
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine($"Error: {error.Description}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    status = false;
                
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }

            return status;
        }





    }
}
