using System;
using System.Data;

namespace WebApplication1.Data
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Stock{ get; set; }
        public decimal  Price { get; set; }
        public DateTime CreateDate { get; set; }
        public string ImagePath { get; set; }   
        public List<Order> orders { get; set;}
    
    }
}
