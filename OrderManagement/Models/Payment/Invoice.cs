using System;
using OrderManagement.Models.Common;

namespace OrderManagement.Models.Payment
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public int ProductId { get; set; }
        public int MemberId { get; set; }
        public PaymentType PaymentTypeId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ShippingId { get; set; }
        public double TotalPrice { get; set; }
        public bool DiscountApplied { get; set; }
        public double Commission { get; set; }
        public int AgentId { get; set; }
    }

    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
