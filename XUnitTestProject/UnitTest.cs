using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication.Services;
using WebApplicationC.Controllers;
using WebApplicationC.Models;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest
    {
        UsuariosController _controller;
        private SampleDataBase context;

        public UnitTest() {
            
            _controller = new UsuariosController(context);
        }

        [Fact]
        public void Get_All_ReturnsOK()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_All_ReturnsAll()
        {
            // Arrange
            var TotalUsuarios = 10; // Supondo que tenham 10 usuarios na base

            // Act
            var okResult = _controller.Get().Result as OkObjectResult;            

            // Assert
            var items = Assert.IsType<List<Usuario>>(okResult.Value);
            Assert.Equal(TotalUsuarios, items.Count);

        }

        [Fact]
        public void Get_IDExistente_ReturnsOK()
        {
            // Arrange
            var testID = 20;

            // Act
            var okResult = _controller.Get(testID).Result as OkObjectResult;

            // Assert
            Assert.IsType<Usuario>(okResult.Value);
            Assert.Equal(testID, (okResult.Value as Usuario).Id);
        }

        [Fact]
        public void Get_IDInexistente_ReturnsNotFoundResult()
        {
            // Arrange
            var testID = 99;

            // Act
            var notFoundResult = _controller.Get(testID);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void Add_ObjetoValido_ReturnsOK()
        {
            // Arrange
            Usuario testItem = new Usuario()
            {
                Nome = "Alex Murat",
                Email = "alexmurat@outlook.com",
                Senha = "senha123"
            };

            // Act
            var createdResponse = _controller.Post(testItem.Nome, testItem.Email, testItem.Senha);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Delete_IDExistente_ReturnsOK()
        {
            // Arrange
            var testID = 20;

            // Act
            var okResponse = _controller.Delete(testID);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }

        [Fact]
        public void Delete_IDExistente_DeleteOK()
        {
            // Arrange
            var testID = 20;
            var TotalUsuarios = 10;

            // Act
            var okResponse = _controller.Delete(testID);

            // Assert
            var okResult = _controller.Get().Result as OkObjectResult;
            var items = Assert.IsType<List<Usuario>>(okResult.Value);
            Assert.Equal(TotalUsuarios - 1, items.Count);
        }

        [Fact]
        public void Delete_IDInexistente_ReturnsNotFoundResponse()
        {
            // Arrange
            var testID = 99;

            // Act
            var badResponse = _controller.Delete(testID);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
    }
}
