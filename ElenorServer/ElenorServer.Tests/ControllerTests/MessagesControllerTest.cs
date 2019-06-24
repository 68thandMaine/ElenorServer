using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElenorServer.Controllers;
using MySql.Data.MySqlClient;
using System;

namespace ElenorServer.Tests
{
    [TestClass]
    public class MessagesTest : IDisposable
    {
        public void Dispose()
        {
            Messages.ClearAll();
        }

        public MessagesTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=elenor_test;";
        }
    }
}
