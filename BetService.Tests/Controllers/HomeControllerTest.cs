﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BetService;
using BetService.Controllers;
using BetService.Repository.Interfaces;

namespace BetService.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        [TestMethod]
        public void Index()
        {
            var IPlayersService = UnityConfig.Resolve<IPlayersService>();
            // Arrange
            HomeController controller = new HomeController(IPlayersService);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            var IPlayersService = UnityConfig.Resolve<IPlayersService>();
            // Arrange
            HomeController controller = new HomeController(IPlayersService);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            var IPlayersService = UnityConfig.Resolve<IPlayersService>();
            // Arrange
            HomeController controller = new HomeController(IPlayersService);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
