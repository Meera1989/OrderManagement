using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderManagement.Controllers;
using OrderManagement.Interface;
using OrderManagement.Models.Common;
using OrderManagement.Models.Payment;

namespace OrderManagement.Tests
{
    [TestClass]
    public class OrderControllerTest
    {
        private Mock<IOrderService> mockOrderService;
        public OrderControllerTest()
        {
            mockOrderService = new Mock<IOrderService>();
        }

        [TestMethod]
        public async Task Invalid_Request_BadRequestResponse()
        {
            //Arrange
            var obj = new OrderController(mockOrderService.Object);
           
            //Act
            var result = await obj.ProceesOrder(null);
            var contentResult = result as ObjectResult;
            //Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual((contentResult.Value as ValidationResult).Message, "Invalid Request.");
            Assert.AreEqual((int)HttpStatusCode.BadRequest, contentResult.StatusCode);

            // "ProductId is required.");
            // mockOrderService.Verify(x => x.ProcessOrder(It.IsAny<OrderRequest>()), Times.Never);
        }

        [TestMethod]
        public async Task Invalid_PaymentId_BadRequestResponse()
        {
            //Arrange
            var obj = new OrderController(mockOrderService.Object);
            var request = GetOrderRequest();
            request.ProductId = 0;
            //Act
            var result = await obj.ProceesOrder(request);
            var contentResult = result as ObjectResult;
            //Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual((contentResult.Value as ValidationResult).Message, "ProductId is required.");
            Assert.AreEqual((int)HttpStatusCode.BadRequest, contentResult.StatusCode);
        }

        [TestMethod]
        public async Task Invalid_MemberIdForProductPayment_BadRequestResponse()
        {
            //Arrange
            var obj = new OrderController(mockOrderService.Object);
            var request = GetOrderRequest();
            request.MemberId = 0;

            //Act
            var result = await obj.ProceesOrder(request);
            var contentResult = result as ObjectResult;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual((contentResult.Value as ValidationResult).Message, "MemberId is required.");
            Assert.AreEqual((int)HttpStatusCode.BadRequest, contentResult.StatusCode);
        }

        [TestMethod]
        public async Task Invalid_MemberInfoForMembershipPayment_BadRequestResponse()
        {
            //Arrange
            var obj = new OrderController(mockOrderService.Object);
            var request = GetOrderRequest();
            request.PaymentTypeId = PaymentType.Membership;
            request.MemberId = 0;
            request.MemberInfo = null;

            //Act
            var result = await obj.ProceesOrder(request);
            var contentResult = result as ObjectResult;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual((contentResult.Value as ValidationResult).Message, "Invalid Member Details.");
            Assert.AreEqual((int)HttpStatusCode.BadRequest, contentResult.StatusCode);
        }

        [TestMethod]
        public async Task Invalid_MembeNameForMembershipPayment_BadRequestResponse()
        {
            //Arrange
            var obj = new OrderController(mockOrderService.Object);
            var request = GetOrderRequest();
            request.PaymentTypeId = PaymentType.Membership;
            request.MemberId = 0;
            request.MemberInfo .Name=null;

            //Act
            var result = await obj.ProceesOrder(request);
            var contentResult = result as ObjectResult;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual((contentResult.Value as ValidationResult).Message, "Invalid Member Details.");
            Assert.AreEqual((int)HttpStatusCode.BadRequest, contentResult.StatusCode);
        }


        [TestMethod]
        public void ValidRequesst_SuccessfullResoonse()
        {

            var obj = new OrderController(mockOrderService.Object);
            var request = GetOrderRequest();
            var result = obj.ProceesOrder(request);
            Assert.IsNotNull(result);
            mockOrderService.Verify(x => x.ProcessOrder(It.IsAny<OrderRequest>()), Times.Once);
        }

        private OrderRequest GetOrderRequest()
        {
            OrderRequest response = new OrderRequest()
            {
                MemberId=1,
                ProductId=1,
                PaymentTypeId=PaymentType.Product,
                MemberInfo = new Models.Membership.Member()
                {
                    Name="Meera",
                    Email="meeratest@test.com",
                    Address1 = "Bangalore",
                    Address2="Mysore",
                    Phone="1234567890",
                    IsShippingInfoSame=true
                }
            };
            return response;
        }

    }
}
