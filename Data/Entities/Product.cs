using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Week1.Data.Entities;

namespace Week1.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        [NotMapped]
        public List<OrderDetails> OrderDetails { get; set; }
    }
}