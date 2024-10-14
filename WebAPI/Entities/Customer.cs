using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entites
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Movie> PurchasedMovies { get; set; }
        public ICollection<Genre> FavoriteGenres { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}