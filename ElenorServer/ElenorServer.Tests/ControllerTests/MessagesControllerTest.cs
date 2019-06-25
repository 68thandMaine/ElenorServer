using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities.Models;
using ElenorServer.Controllers;
using Repository;
using System;
using System.Collections.Generic;
using Contracts;


namespace ElenorServer.Tests
{
    [TestClass]
    public class MessagesTest : IDisposable
    {
        private IRepositoryWrapper _repository;


        public void Dispose()
        {
            _repository.Messages.ClearAll("Messages");
        }
        [TestInitialize]
        public void Initalize()
        {
            _repository = new RepositoryWrapper();
        }
        [TestMethod]
        public void GetAllMessages_ReturnsEmptyList()
        {
            // Arrange
            List<Messages> newList = new List<Messages> { };

            // Act
            List<Messages> result = _repository.Messages.GetAllMessages();

            // Assert
            Assert.AreEqual(newList.Count, result.Count);
        }

        //[TestMethod]
        //public void CreateMessage_ShouldCreateANewMessage()
        //{
        //    MessagesController controller = new MessagesController();
        //    Messages newMessge = new Messages("96e515ee-f057-460b-8c5c-7240e82aae44", "Perciville", "Pennyman", "pingbatpennyman@gmail.com", "Demands!", "To the parents of the infamous Pingbat Pennyman.I hereby renounce my formal name of Perciville and request my inheritance pronto.I am a failed bank robber.Your son - P.", "2019-06-24", false, false);
        //}
    }
}