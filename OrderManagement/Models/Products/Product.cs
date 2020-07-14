using System;
namespace OrderManagement.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public ProductType productType { get; set; }
    }

    public enum ProductType
    {
        Book=1,
        Video=2
    }



}
