using EShop.Domain.Domain;
using EShop.Domain.DTO;
using EShop.Repository.Interface;
using EShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<BookInOrder> _orderRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<BookInShoppingCart> _bookInShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository,
            IRepository<BookInShoppingCart> bookInShoppingCartRepository,
            IUserRepository userRepository,
             IRepository<BookInOrder> orderRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _bookInShoppingCartRepository = bookInShoppingCartRepository;
            _userRepository = userRepository;
        }

        public bool AddToShoppingConfirmed(BookInShoppingCart model, string userId)
        {
            var loggedInUser = _userRepository.Get(userId);

            var userShoppingCart = loggedInUser.ShoppingCart;

            if (userShoppingCart.BookInShoppingCarts == null)
                userShoppingCart.BookInShoppingCarts = new List<BookInShoppingCart>(); ;

            userShoppingCart.BookInShoppingCarts.Add(model);
            _shoppingCartRepository.Update(userShoppingCart);
            return true;
        }

        public bool deleteBookFromShoppingCart(string userId, Guid bookId)
        {
            if (bookId != null)
            {
                var loggedInUser = _userRepository.Get(userId);

                var userShoppingCart = loggedInUser.ShoppingCart;
                var book = userShoppingCart.BookInShoppingCarts.Where(x => x.BookId == bookId).FirstOrDefault();

                userShoppingCart.BookInShoppingCarts.Remove(book);

                _shoppingCartRepository.Update(userShoppingCart);
                return true;
            }
            return false;
        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            var loggedInUser = _userRepository.Get(userId);

            var userShoppingCart = loggedInUser?.ShoppingCart;
            var allBooks = userShoppingCart?.BookInShoppingCarts?.ToList();

            var totalPrice = allBooks.Select(x => (x.Book.Price * x.Quantity)).Sum();

            ShoppingCartDto dto = new ShoppingCartDto
            {
                Books = allBooks,
                TotalPrice = totalPrice
            };
            return dto;
        }

        public bool order(string userId)
        {
            if (userId == null)
                return false;

            var loggedInUser = _userRepository.Get(userId);

            var userShoppingCart = loggedInUser?.ShoppingCart;
          
        
            Order order = new Order
            {
                Id = Guid.NewGuid(),
                userId = userId,
                User = loggedInUser
            };

            List<BookInOrder> booksInOrder = new List<BookInOrder>();

            var rez = userShoppingCart.BookInShoppingCarts.Select(
                z => new BookInOrder
                {
                    Id = Guid.NewGuid(),
                    BookId = z.Book.Id,
                    Book = z.Book,
                    OrderId = order.Id,
                    Order = order,
                    Quantity = z.Quantity
                }).ToList();


            StringBuilder sb = new StringBuilder();

            var totalPrice = 0.0;

            sb.AppendLine("Your order is completed. The order conatins: ");

            for (int i = 1; i <= rez.Count(); i++)
            {
                var currentItem = rez[i - 1];
                totalPrice += currentItem.Quantity * currentItem.Book.Price;
                sb.AppendLine(i.ToString() + ". " + currentItem.Book.Title + " with quantity of: " + currentItem.Quantity + " and price of: $" + currentItem.Book.Price);
            }

            sb.AppendLine("Total price for your order: " + totalPrice.ToString());
           

            booksInOrder.AddRange(rez);

            foreach (var book in booksInOrder)
            {
                _orderRepository.Insert(book);
            }

            loggedInUser.ShoppingCart.BookInShoppingCarts.Clear();
            _userRepository.Update(loggedInUser);
           

            return true;
        }


    }
}
