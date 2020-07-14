using System;
namespace OrderManagement.Models.Membership
{
    public class ShippingInfo
    {
        public int MemberId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
