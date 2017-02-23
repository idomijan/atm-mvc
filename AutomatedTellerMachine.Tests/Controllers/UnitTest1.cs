using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedTellerMachine.Controllers;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FooActionReturnsAboutView()
        {
            var homeController = new HomeController();
            var result = homeController.Foo() as ViewResult;
            Assert.AreEqual("About", result.ViewName);
        }
        [TestMethod]
        public void ContactFormSaysThanks()
        {
            var HomeController = new HomeController();
            var result = HomeController.Contact("Hello Bank") as ViewResult;
            Assert.AreEqual("Thanks!", result.ViewBag.TheMessage);
        }
    }
}
