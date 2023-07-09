using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCustomer.Entity
{
    internal class Order
    {
        public Guid customerId { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public DateTime createdDate { get; set; }
    }
}
