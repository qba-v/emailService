
using Domain.DAL.Commands.Interfaces;
using Domain.DAL.Entities;
using Domain.DAL.Queries.Interfaces;
using EmailService.Controllers;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test
{
    public class EmailControllerTests
    {
        private EmailController _emailController;

        [SetUp]
        public void Setup()
        {
            var mockConfig = new Mock<IConfiguration>();
            var mockEmailCommands = new Mock<IEmailCommands>();
            var mockEmailQueries = new Mock<IEmailQueries>();

            _emailController = new EmailController(mockConfig.Object, mockEmailCommands.Object, mockEmailQueries.Object);
        }

        [Test]
        public void CreateEmail()
        {
            var result = _emailController.CreateEmail(new Domain.Entities.Email
            {
                Subject = "Tytu³",
                Content = "Opis",
                Sender = "sender@codility.com",
                Recipients = new List<Recipient>
                    {
                    new Recipient
                    {
                        Address = "example@gmail.com"
                    }
                }
            });

            var okResult = result as Microsoft.AspNetCore.Mvc.OkObjectResult;

            Assert.AreEqual(okResult.StatusCode, 200);
        }

        [Test]
        public void GetAllEmail()
        {
            var result = _emailController.Get();

            var okResult = result as Microsoft.AspNetCore.Mvc.OkObjectResult;

            Assert.AreEqual(okResult.StatusCode, 200);
        }
    }
}