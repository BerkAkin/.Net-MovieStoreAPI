using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entites
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        public int Price { get; set; }
        public DateTime PurchaseDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}