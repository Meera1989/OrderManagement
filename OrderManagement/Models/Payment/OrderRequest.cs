using System;
namespace OrderManagement.Models.Payment
{
    public class OrderRequest
    {
        public int ProductId { get; set; }
        public int MemberId { get; set; }
    }
}
