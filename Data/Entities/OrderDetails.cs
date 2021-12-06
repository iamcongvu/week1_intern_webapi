using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week1.Data.Entities
{
    public class OrderDetails
    {
        public int ProductId { get; set; }
        public int Orderid { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}