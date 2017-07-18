using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorldApi.Controllers;

namespace HelloWorldApi.Tests.Controllers
{
    [TestClass]
    public class MessageControllerTest
    {
        [TestMethod]
        public void GetMessage()
        {
            // Arrange
            MessageController controller = new MessageController();

            // Act
            var result = controller.GetMessage();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Hello World!", result);
        }
    }
}
