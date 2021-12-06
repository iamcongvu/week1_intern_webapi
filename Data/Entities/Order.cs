using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Week1.Data.Entities;

namespace Week1.Data
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        [NotMapped]
        public List<OrderDetails> OrderDetails { get; set; }
    }
}