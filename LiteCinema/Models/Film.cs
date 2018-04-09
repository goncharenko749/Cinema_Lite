using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteCinema.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public double Price { get; set; }
    }
}
