using System;
using System.Linq;
using OrderManagement.Interface;
using OrderManagement.Models.Common;
using OrderManagement.Models.Membership;

namespace OrderManagement.Services
{
    public class MemberService : IMemberService
    {
        public int AddUpdateMember(Member request,bool createIfNotExists=false)
        {
            if(createIfNotExists)
            {
                //Create and return MemberId
                return 2;
            }
            else
            {
                //Update and return MemberId
                return request.Id;
            }
        }

        public Member GetMember(int memberId)
        {
            Member result = new Member();
            var members = Utility.GetMemberData();
            if (members != null)
            {
                result = members.Where(x => x.Id == memberId).FirstOrDefault();
            }
            return result;
        }

        public ShippingInfo AddUpdateShippingInfo(ShippingInfo request)
        {
            //Create if not exists else update
            return new ShippingInfo()
            {
                Address1 = request.Address1,
                Address2 = request.Address2,
                Email = request.Email,
                Phone = request.Phone
            };
        }

        public int GetShippingInfoByMemberId(int memberId)
        {
            var result = Utility.GetShippingData().Where(x => x.MemberId == memberId).FirstOrDefault();
            return result.MemberId;

        }
    }
}
