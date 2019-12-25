using LibraryUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LibraryTest
{
    [TestClass]
    public class BooksControllerTest
    {
        [TestMethod]
        public void TestIndexViewWithNoLogin()
        {
            //AAA -> Arrange , Act and Assert
            //Arrange
            var controller = new BooksController();

            //Act
            Assert.ThrowsException<NullReferenceException>(() => controller.Index());
        }
        [TestMethod]
        public void TestIndexViewWithEmptyLogin()
        {
            //AAA -> Arrange , Act and Assert
            //Arrange
            var controller = new BooksController();
            controller.username = string.Empty;
            //Act
            Assert.ThrowsException<ArgumentNullException>(() => controller.Index());
        }
    }
}

