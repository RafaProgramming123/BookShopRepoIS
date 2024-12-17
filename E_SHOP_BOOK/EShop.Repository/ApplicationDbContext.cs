
using EShop.Domain.Domain;
using EShop.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.Repository
{
    public class ApplicationDbContext : IdentityDbContext<EShopApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookPublisher> BooksPublisher { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }

        public virtual DbSet<BookInShoppingCart> BookInShoppingCart { get; set; }

        public virtual DbSet<BookInOrder> BookInOrder { get; set; }
    }
}
