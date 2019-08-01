using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities.Models;
using Repository;
using ElenorServer.Controllers;
using System.Collections.Generic;
using Contracts;
using Moq;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace ElenorServer.Tests
{
    [TestClass]
    public class MessageControllerTest
    {
        Mock<RepositoryContext> _repository = new Mock<RepositoryContext>();
        Mock<DbSet<Message>> _msgDbSet = new Mock<DbSet<Message>>();
        Mock<IRepositoryWrapper> msgRepo = new Mock<IRepositoryWrapper>();
        Mock<Message> _message = new Mock<Message>();
        private MessageController messageController;
        private void DbSetup()
        {
            _repository.Setup(r => r.Set<Message>()).Returns(_msgDbSet.Object);
            _msgDbSet.Setup(mDbS => mDbS.Add(It.IsAny<Message>())).Returns(_message);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            messageController = new MessageController(null, msgRepo.Object);
        }
        [TestMethod]
        public void MessageController_IndexModelContainsCorrecData_List()
        {
            var mockMsgDbSet = new Mock<DbSet<Message>>();
            //var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();


            //var mockContext = new Mock<RepositoryContext>();
            //mockContext.Setup(m => m.Message).Returns(mockMsgDbSet.Object);

            //var controller = new MessageController(null, mockRepositoryWrapper.Object);



        }

    }
}
