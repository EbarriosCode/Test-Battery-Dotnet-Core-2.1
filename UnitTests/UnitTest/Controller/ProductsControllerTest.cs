using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WebTesting.Controllers;
using WebTesting.Models;
using WebTesting.Service;

namespace UnitTests.UnitTest.Controller
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void ListProducts_Test()
        {
            //Arrange
            var mockService = new Mock<IProductService>();
            mockService.Setup(test => test.GetList()).Returns(GetProducts());
            var controller = new ProductsController(mockService.Object);

            //Act
            ViewResult result = controller.Index() as ViewResult;
            var productos = (List<Products>)result.Model;

            //Assert
            Assert.AreEqual(3, productos.Count);
            Assert.IsNotNull(result);
        }

        private IEnumerable<Products> GetProducts()
        {
            var productos = new List<Products>()
            {
                new Products { Name = "Tablet", Price = 3000, Description = "Tablet Portatil Samsumg" },
                new Products { Name = "Celular", Price = 1500, Description = "Celular Samsumg J7" },
                new Products { Name = "Monitor", Price = 1500, Description = "Monitor Dell 39 plg" }
            };

            return productos;
        }
    }
}
