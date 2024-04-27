﻿namespace ProductApp.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } 
        public string Image { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set;}
    }
}
