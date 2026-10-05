using Microsoft.EntityFrameworkCore;

namespace Library_System.Models
{
    public class My_AppContext : DbContext  
    {
        public My_AppContext(DbContextOptions<My_AppContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Member>()
                .HasMany(m => m.Borrowings)
                .WithOne(b => b.Member)
                .HasForeignKey(b => b.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.Member)
                .WithMany(m => m.Borrowings)
                .HasForeignKey(b => b.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Borrowing>()
               .HasOne(b => b.Book)
               .WithMany(m => m.Borrowings)
               .HasForeignKey(b => b.BookId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Member>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Book>().HasIndex(x => x.ISBN).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction", Description = "Fictional books" },
                new Category { Id = 2, Name = "Non-Fiction", Description = "Non-fictional books" },
                new Category { Id = 3, Name = "Science", Description = "Science books" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "9780743273565", CategoryId = 1 },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "9780060935467", CategoryId = 1 },
                new Book { Id = 3, Title = "A Brief History of Time", Author = "Stephen Hawking", ISBN = "9780553380163", CategoryId = 3 }
            );

            modelBuilder.Entity<Member>().HasData(new Member { Id = 1, Email = "basil@gmail.com", FullName = "Basil Mohamed", Phone = "1234567890" });
            modelBuilder.Entity<Member>().HasData(new Member { Id = 2, Email = "mohamed@gmail.com", FullName = "Mohamed Ahmed", Phone = "1234567891" });
            modelBuilder.Entity<Member>().HasData(new Member { Id = 3, Email = "ahmed@gmail.com", FullName = "Ahmed Mohamed", Phone = "1234567893" });

            modelBuilder.Entity<Borrowing>().HasData(
                new Borrowing { Id = 1, BorrowDate = DateTime.Now.AddDays(-10), ReturnDate = null, MemberId = 1, BookId = 1 },
                new Borrowing { Id = 2, BorrowDate = DateTime.Now.AddDays(-5), ReturnDate = null, MemberId = 2, BookId = 2 }
            );



            base.OnModelCreating(modelBuilder);
        }
    }
}
