using System;
using OrderManagement.Models.Membership;

namespace OrderManagement.Interface
{
    public interface IMemberService
    {

        int AddUpdateMember(Member request, bool createIfNotExists = false);
        Member GetMember(int memberId);
        ShippingInfo AddUpdateShippingInfo(ShippingInfo request);
        int GetShippingInfoByMemberId(int memberId);
    }
}
