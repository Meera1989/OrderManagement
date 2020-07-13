using System;
using OrderManagement.Models.Payment;
using System.Threading.Tasks;

namespace OrderManagement.Interface
{
    public interface IOrderService
    {
        Task<OrderResponse> ProcessOrder(OrderRequest request);
    }
}
