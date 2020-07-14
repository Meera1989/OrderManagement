using System;
using OrderManagement.Models.Common;
using OrderManagement.Models.Membership;

namespace OrderManagement.Models.Payment
{
    public class OrderRequest
    {
        public int ProductId { get; set; }
        public int MemberId { get; set; }
        public PaymentType PaymentTypeId { get; set; }
        public Member MemberInfo { get; set; }
    }
}
