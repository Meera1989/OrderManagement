using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderManagement.Interface;
using OrderManagement.Models.Common;
using OrderManagement.Models.Payment;
using OrderManagement.Models.Products;
using OrderManagement.Services;

namespace OrderManagement.Tests
{
    [TestClass]
    public class OrderServiceTest
    {
        private Mock<IMemberService> mockMemberService;
        private Mock<IProductService> mockProductService;

        public OrderServiceTest()
        {
            mockMemberService = new Mock<IMemberService>();
            mockProductService = new Mock<IProductService>();
        }


        [TestMethod]
        public async Task ValidRequest_ProcessOrderForProductPayment_SuccessfulResponse()
        {
            var obj = new OrderService(mockMemberService.Object, mockProductService.Object);
            var request = GetOrderRequest();
            mockProductService.Setup(x => x.GetProduct(request.ProductId)).Returns(new Product() { Id=1, UnitPrice=100});

            var result = await obj.ProcessOrder(request);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.OrderId);
            mockProductService.Verify(x => x.GetProduct(request.ProductId), Times.Once);
        }

        [TestMethod]
        public async Task ValidRequest_ProcessOrderForMembershipPayment_SuccessfulResponse()
        {
            var obj = new OrderService(mockMemberService.Object, mockProductService.Object);
            var request = GetOrderRequest();
            request.PaymentTypeId = PaymentType.Membership;
            mockProductService.Setup(x => x.GetProduct(request.ProductId)).Returns(new Product() { Id = 1, UnitPrice = 100 });

            var result = await obj.ProcessOrder(request);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.OrderId);
            mockProductService.Verify(x => x.GetProduct(request.ProductId), Times.Once);
        }


        private Models.Payment.OrderRequest GetOrderRequest()
        {
            OrderRequest response = new OrderRequest()
            {
                MemberId = 1,
                ProductId = 1,
                PaymentTypeId = PaymentType.Product,
                MemberInfo = new Models.Membership.Member()
                {
                    Name = "Meera",
                    Email = "meeratest@test.com",
                    Address1 = "Bangalore",
                    Address2 = "Mysore",
                    Phone = "1234567890",
                    IsShippingInfoSame = true
                }
            };
            return response;
        }
    }
}
