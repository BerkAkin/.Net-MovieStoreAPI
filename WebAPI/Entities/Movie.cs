using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entites
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime Year { get; set; }
        public ICollection<Genre> Genres { get; set; }


    }
}