using System;
using System.Linq;
using OrderManagement.Interface;
using OrderManagement.Models.Common;
using OrderManagement.Models.Products;

namespace OrderManagement.Services
{
    public class ProductService : IProductService
    {
        public Product GetProduct(int productId)
        {
            Product result = new Product();
            var products = Utility.GetProductData();
            if(products!=null)
            {
                result = products.Where(x => x.Id == productId).FirstOrDefault();
            }
            return result;
        }
    }
}
