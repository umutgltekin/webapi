using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace WebApplication1.Data
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int TotalOrders { get; set; }
        public int  OrderAmount { get; set; }
        public Product product { get; set; }
        public Customer customer { get; set; }

    }
}
