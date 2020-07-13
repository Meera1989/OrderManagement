using System;
namespace OrderManagement.Models.Payment
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public bool IsSuccess { get; set; }
    }
}
