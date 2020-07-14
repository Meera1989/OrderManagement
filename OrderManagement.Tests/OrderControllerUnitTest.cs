using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderManagement.Controllers;
using OrderManagement.Interface;
using OrderManagement.Models.Payment;

namespace OrderManagement.Tests
{
    [TestClass]
    public class OrderControllerUnitTest
    {
        [TestMethod]
        public void ValidRequesst_SuccessfullResoonse()
        {
            Mock<IOrderService> mockOrderService = new Mock<IOrderService>();
            var obj = new OrderController(mockOrderService.Object);
            var result = obj.ProceesOrder(1, 1);
            Assert.IsNotNull(result);
            mockOrderService.Verify(x => x.ProcessOrder(It.IsAny<OrderRequest>()), Times.Once);
        }
    }
}
