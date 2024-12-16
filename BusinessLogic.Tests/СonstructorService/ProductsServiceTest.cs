﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Wrapper;
using Moq;
using Xunit.Sdk;

namespace BusinessLogic.Tests.СonstructorService
{
    public class ProductServiceTest
    {
        private readonly ProductsService service;
        private readonly Mock<IProductsRepository> ProductRepositoryMoq;

        public static IEnumerable<object[]> CreateIncorrectProduct()
        {
            return new List<object[]>
            {
                new object[] { new Product() { Product1 = "", Calories = -111.0m, ProteinPer = -111.0m, FatPer = -111.0m, CarbsPer = -111.0m, VitaminsAndMinerals = "", NutritionalValue = "" } },
                new object[] { new Product() { Product1 = "sdsd", Calories = -111.0m, ProteinPer = -111.0m, FatPer = -111.0m, CarbsPer = -111.0m, VitaminsAndMinerals = "", NutritionalValue = "" } },
                new object[] { new Product() { Product1 = "111", Calories = 111.0m, ProteinPer = -111.0m, FatPer = 111.0m, CarbsPer = -111.0m, VitaminsAndMinerals = "sdsd", NutritionalValue = "" } },
            };
        }

        public static IEnumerable<object[]> CreateCorrectProduct()
        {
            return new List<object[]>
            {
                new object[] { new Product() { Product1 = "sddss", Calories = 111.0m, ProteinPer = 111.0m, FatPer = 111.0m, CarbsPer = 111.0m, VitaminsAndMinerals = "dssd", NutritionalValue = "dsds" } },
                new object[] { new Product() { Product1 = "sddss1", Calories = 121.0m, ProteinPer = 111.0m, FatPer = 111.0m, CarbsPer = 111.0m, VitaminsAndMinerals = "dssd", NutritionalValue = "dsds" } },
                new object[] { new Product() { Product1 = "sddss2", Calories = 111.0m, ProteinPer = 131.0m, FatPer = 111.0m, CarbsPer = 111.0m, VitaminsAndMinerals = "dssd", NutritionalValue = "dsds" } },
            };
        }
        public static IEnumerable<object[]> GetIncorrectProduct()
        {
            return new List<object[]>
            {
                new object[] { new Product() {ProductId=0, Product1 = "", Calories = -111.0m, ProteinPer = -111.0m, FatPer = -111.0m, CarbsPer = -111.0m, VitaminsAndMinerals = "", NutritionalValue = "" } },
                new object[] { new Product() {ProductId=-1, Product1 = "dsds", Calories = -111.0m, ProteinPer = -111.0m, FatPer = -111.0m, CarbsPer = -111.0m, VitaminsAndMinerals = "", NutritionalValue = "sds" } },
            };
        }

        public static IEnumerable<object[]> GetCorrectProduct()
        {
            return new List<object[]>
            {
                new object[] { new Product() {ProductId=1,  Product1 = "sddss", Calories = 111.0m, ProteinPer = 111.0m, FatPer = 111.0m, CarbsPer = 111.0m, VitaminsAndMinerals = "dssd", NutritionalValue = "dsds" } },
                new object[] { new Product() {ProductId=2,  Product1 = "sddss", Calories = 111.0m, ProteinPer = 111.0m, FatPer = 111.0m, CarbsPer = 111.0m, VitaminsAndMinerals = "dssd", NutritionalValue = "dsds" } },
            };
        }


        public ProductServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            ProductRepositoryMoq = new Mock<IProductsRepository>();

            repositoryWrapperMoq.Setup(x => x.Products).Returns(ProductRepositoryMoq.Object);

            service = new ProductsService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task GetALL()
        {
            await service.GetAll();
            ProductRepositoryMoq.Verify(x => x.FindALL());
        }


        [Theory]
        [MemberData(nameof(GetCorrectProduct))]
        public async Task GetById_correct(Product Product)
        {
            ProductRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<Product, bool>>>())).ReturnsAsync(new List<Product> { Product });

            // Act
            var result = await service.GetById(Product.ProductId);

            // Assert
            Assert.Equal(Product.ProductId, result.ProductId);
            ProductRepositoryMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<Product, bool>>>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectProduct))]
        public async Task GetByid_incorrect(Product Product)
        {
            ProductRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<Product, bool>>>())).ReturnsAsync(new List<Product> { Product });

            // Act
            var result = await service.GetById(Product.ProductId);

            // Assert
            Assert.Equal(Product.ProductId, result.ProductId);
            ProductRepositoryMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<Product, bool>>>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(CreateCorrectProduct))]

        public async Task CreateAsyncNewProductShouldNotCreateNewProduct_correct(Product Product)
        {
            var newProduct = Product;

            await service.Create(newProduct);
            ProductRepositoryMoq.Verify(x => x.Create(It.IsAny<Product>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(CreateIncorrectProduct))]

        public async Task CreateAsyncNewProductShouldNotCreateNewProduct_incorrect(Product Product)
        {
            var newProduct = Product;

           await service.Create(newProduct);
           ProductRepositoryMoq.Verify(x => x.Create(It.IsAny<Product>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetCorrectProduct))]

        public async Task UpdateAsyncOldProduct_correct(Product Product)
        {
            var newProduct = Product;

            await service.Update(newProduct);
            ProductRepositoryMoq.Verify(x => x.Update(It.IsAny<Product>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectProduct))]

        public async Task UpdateAsyncOldProduct_incorrect(Product Product)
        {
            var newProduct = Product;

            await service.Update(newProduct);
            ProductRepositoryMoq.Verify(x => x.Update(It.IsAny<Product>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetCorrectProduct))]

        public async Task DeleteAsyncOldProduct_correct(Product Product)
        {
            ProductRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<Product, bool>>>())).ReturnsAsync(new List<Product> { Product });

            await service.Delete(Product.ProductId);

            ProductRepositoryMoq.Verify(x => x.Delete(It.IsAny<Product>()), Times.Once);
            var result = await service.GetById(Product.ProductId);
            Assert.Equal(Product.ProductId, result.ProductId);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectProduct))]

        public async Task DeleteAsyncOldProduct_incorrect(Product Product)
        {
            ProductRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<Product, bool>>>())).ReturnsAsync(new List<Product> { Product });

            await service.Delete(Product.ProductId);

            ProductRepositoryMoq.Verify(x => x.Delete(It.IsAny<Product>()), Times.Once);
            var result = await service.GetById(Product.ProductId);
            Assert.Equal(Product.ProductId, result.ProductId);
        }

    }
}
