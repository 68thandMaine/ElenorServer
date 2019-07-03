using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Entities.Models;
using ElenorServer.Controllers;
using Repository;
using System;
using Entities;
using System.Collections.Generic;
using Contracts;


namespace ElenorServer.Tests
{
    [TestClass]
    public class MessagesTest
    {
        private IRepositoryWrapper _repository;

        public MessagesTest(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [TestMethod]
        public void GetAllMessages_ReturnsEmptyList()
        {
            // Arrange
            MessagesController controller = new MessagesController();
            List<Messages> emptyList = new List<Messages> { };
            // Act
            List<Messages> messageList = _repository.Messages.GetAllMessages();

            // Assert
            Assert.AreEqual(emptyList, messageList);
        }

        //[TestMethod]
        //public void CreateMessage_ShouldCreateANewMessage()
        //{
        //    MessagesController controller = new MessagesController();
        //    Messages newMessge = new Messages("96e515ee-f057-460b-8c5c-7240e82aae44", "Perciville", "Pennyman", "pingbatpennyman@gmail.com", "Demands!", "To the parents of the infamous Pingbat Pennyman.I hereby renounce my formal name of Perciville and request my inheritance pronto.I am a failed bank robber.Your son - P.", "2019-06-24", false, false);
        //}
    }
}