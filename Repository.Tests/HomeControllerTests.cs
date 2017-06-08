using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MoqRepositoryCore.Data;
using Web.Controllers;
using Xunit;

namespace Controllers.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexReturnsAViewResultWithAListOfPhones()
        {
            // Arrange // maybe constructor and property?
            var mock = new Mock<IRepository<Product>>();
            mock.Setup(repo => repo.FindAll()).Returns(GetTestProducts);
            var controller = new HomeController<Product>(mock.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.Model);
            Assert.Equal(GetTestProducts().Count, model.Count());
        }

        private List<Product> GetTestProducts()
        {
            return new List<Product>
            {
                new Product { ProductId = 1, Name = "C# 7.1",
                    Description = "Cool update", Price = 49.99 },
                new Product { ProductId = 2, Name = "ASP.NET Core",
                    Description = "My love and my pain", Price = 59.99 },
                new Product { ProductId = 3, Name = "Visual Basic",
                    Description = "What? I'm really too young to be feeling this old!", Price = 29.99 }
            };
        }
    }
}
