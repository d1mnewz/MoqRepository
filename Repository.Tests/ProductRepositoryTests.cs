using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using MoqRepositoryCore;

namespace Repository.Tests
{
    [TestClass]
    public class ProductRepositoryTests
    {

     public TestContext TestContext { get; set; }

    private readonly IProductRepository _mockProductsRepository;


        public ProductRepositoryTests()
        {
            #region Initial MockRepository setup

            IList<Product> products = new List<Product>
            {
                new Product { ProductId = 1, Name = "C# 7.1",
                    Description = "Cool update", Price = 49.99 },
                new Product { ProductId = 2, Name = "ASP.NET Core",
                    Description = "My love and my pain", Price = 59.99 },
                new Product { ProductId = 3, Name = "Visual Basic",
                    Description = "What? I'm really too young to be feeling this old!", Price = 29.99 }
            };

            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository.Setup(mr => mr.FindAll()).Returns(products);

            mockProductRepository.Setup(mr => mr.FindById(
                It.IsAny<int>())).Returns((int i) => products.Single(x => x.ProductId == i));

            mockProductRepository.Setup(mr => mr.FindByName(
                It.IsAny<string>())).Returns((string s) => products.Single(x => x.Name == s));

            mockProductRepository.Setup(mr => mr.Save(It.IsAny<Product>())).Returns(
                (Product target) => // in real project should be replaced with a function just as other methods tho
                {
                    DateTime now = DateTime.Now;

                    if (target.ProductId.Equals(default(int)))
                    {
                        target.DateCreated = now;
                        target.DateModified = now;
                        target.ProductId = products.Count() + 1;
                        products.Add(target);
                    }
                    else
                    {
                        var original = products.Single(q => q.ProductId == target.ProductId);

                        if (original == null)
                        {
                            return false;
                        }

                        original.Name = target.Name;
                        original.Price = target.Price;
                        original.Description = target.Description;
                        original.DateModified = now;
                    }

                    return true;
                });

            this._mockProductsRepository = mockProductRepository.Object;

            #endregion


        }

        [TestMethod]
        public void CanReturnProductById()
        {
            var testProduct = this._mockProductsRepository.FindById(2);

            Assert.IsNotNull(testProduct);
            Assert.IsInstanceOfType(testProduct, typeof(Product));
            Assert.AreEqual("ASP.NET Core", testProduct.Name);
        }

        [TestMethod]
        public void CanReturnProductByName()
        {
            var testProduct = this._mockProductsRepository.FindByName("Visual Basic");

            Assert.IsNotNull(testProduct);
            Assert.IsInstanceOfType(testProduct, typeof(Product));
            Assert.AreEqual(3, testProduct.ProductId);
        }

        [TestMethod]
        public void CanReturnAllProducts()
        {
            var testProducts = this._mockProductsRepository.FindAll();

            Assert.IsNotNull(testProducts);
            Assert.AreEqual(3, testProducts.Count);
        }

        [TestMethod]
        public void CanInsertProduct()
        {
            Product newProduct = new Product
                { Name = "C# 7.3", Description = "Short description here", Price = 39.99 };
            int productCount = this._mockProductsRepository.FindAll().Count;
            Assert.AreEqual(3, productCount);

            this._mockProductsRepository.Save(newProduct);

            productCount = this._mockProductsRepository.FindAll().Count;
            Assert.AreEqual(4, productCount);

            Product testProduct = this._mockProductsRepository.FindByName("C# 7.3");
            Assert.IsNotNull(testProduct);
            Assert.IsInstanceOfType(testProduct, typeof(Product));
            Assert.AreEqual(4, testProduct.ProductId);
        }

        [TestMethod]
        public void CanUpdateProduct()
        {
            Product testProduct = this._mockProductsRepository.FindById(1);
            testProduct.Name = "C# 7.2";

            this._mockProductsRepository.Save(testProduct);

            Assert.AreEqual("C# 7.2", this._mockProductsRepository.FindById(1).Name);
        }
    }
}

