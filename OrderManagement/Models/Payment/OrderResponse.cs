using System;
using OrderManagement.Models.Common;

namespace OrderManagement.Models.Payment
{
    public class OrderResponse:ValidationResult
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }

    }
}
