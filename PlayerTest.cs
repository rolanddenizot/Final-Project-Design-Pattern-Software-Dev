using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Player player1 = new Player("Roland");
            player1.toString();
        }

        [TestMethod]
        public void TestMethod2()
        {
            Game monop = new Game();
            Player player1 = new Player("Roland");
            monop.DisplayPosition(player1);
        }
    }
}
