using System;
namespace OrderManagement.Models.Membership
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfJoin { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsShippingInfoSame { get; set; }
    }
}
