using System;
using OrderManagement.Models.Products;

namespace OrderManagement.Interface
{
    public interface IProductService
    {
        Product GetProduct(int ProductId);
    }
}
