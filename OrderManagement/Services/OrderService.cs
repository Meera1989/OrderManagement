using System;
using System.Threading.Tasks;
using OrderManagement.Interface;
using OrderManagement.Models.Payment;

namespace OrderManagement.Services
{
    public class OrderService:IOrderService
    {
        public async Task<OrderResponse> ProcessOrder(OrderRequest request)
        {
            OrderResponse result = new OrderResponse()
            {
                OrderId = 1,
                OrderNo = "A001",
                IsSuccess = true
            };
            return result;
        }
    }
}
