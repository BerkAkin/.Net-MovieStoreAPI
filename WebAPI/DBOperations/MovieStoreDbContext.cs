using Microsoft.EntityFrameworkCore;
using WebAPI.Entites;

namespace WebAPI.DBOperations
{
    public class MovieStoreDbContext : DbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(a => a.Movies);

            modelBuilder.Entity<Movie>()
                .HasOne(p => p.Producer)
                .WithMany(m => m.Movies)
                .HasForeignKey(m => m.ProducerId);

            modelBuilder.Entity<Customer>()
                .HasMany(m => m.PurchasedMovies)
                .WithMany(c => c.Customers)
                .UsingEntity(j => j.ToTable("CustomerMovies"));

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.FavoriteGenres)
                .WithMany(g => g.Customers)
                .UsingEntity(j => j.ToTable("CustomerFavoriteGenres"));

            modelBuilder.Entity<Customer>()
                .HasMany(o => o.Orders)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}