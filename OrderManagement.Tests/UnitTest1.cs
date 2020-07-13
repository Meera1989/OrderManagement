using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderManagement.Controllers;
using OrderManagement.Interface;

namespace OrderManagement.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidRequesst_SuccessfullResoonse()
        {
            Mock<IOrderService> mockOrderService = new Mock<IOrderService>();
            var obj = new OrderController(mockOrderService.Object);
            var result = obj.ProceesOrder(1, 1);
            Assert.IsNotNull(result);
        }
    }
}
