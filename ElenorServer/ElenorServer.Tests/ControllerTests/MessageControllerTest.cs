using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities.Models;
using ElenorServer.Controllers;
using System.Collections.Generic;
using Contracts;
using System;
using Microsoft.AspNetCore.Mvc;

namespace ElenorServer.Tests
{
    [TestClass]
    public class MessageControllerTest
    {
        [TestMethod]
        public void MessageController_IndexModelContainsCorrecData_List()
        {
            // Arrange
            MessageController controller = new MessageController(null, null); // Create a new controller
            IActionResult actionResult = controller.Index();
            OkObjectResult indexResult = controller.Index() as OkObjectResult;
        }
    }
}