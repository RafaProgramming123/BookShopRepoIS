using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EShop.Domain.Domain;
using EShop.Repository;
using EShop.Service.Interface;
using EShop.Service.Implementation;
using System.Security.Claims;
using EShop.Service.implementation;

namespace EShop.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly IShoppingCartService _shoppingCartService;

        public BooksController(IBookService bookService,IShoppingCartService shoppingCartService,IAuthorService authorService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
            _shoppingCartService = shoppingCartService;
        }


        // GET: Books
        public async Task<IActionResult> Index()
        {
           var books=bookService.GetAllBooks();
            return View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = bookService.GetDetailsForBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            var authors = authorService.GetAllAuthors(); 
            ViewData["Authors"] = new SelectList(authors, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Price,Rating,Genre,Image,AuthorId,Id")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = Guid.NewGuid();
                bookService.CreateNewBook(book);
                return RedirectToAction(nameof(Index));
            }
        
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
             var book=bookService.GetDetailsForBook(id);
           
            if (book == null)
            {
                return NotFound();
            }
          
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Description,Price,Rating,Genre,Image,AuthorId,Id")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bookService.UpdateExistingBook(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                 
                        throw;
                   
                }
                return RedirectToAction(nameof(Index));
            }
    
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = bookService.GetDetailsForBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddToCart(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = bookService.GetDetailsForBook(id);

            BookInShoppingCart bs = new BookInShoppingCart();

            if (book != null)
            {
                bs.BookId = book.Id;
            }

            return View(bs);
        }

        [HttpPost]
        public IActionResult AddToCartConfirmed(BookInShoppingCart model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _shoppingCartService.AddToShoppingConfirmed(model, userId);

            return View("Index", bookService.GetAllBooks());
        }


    }
}
