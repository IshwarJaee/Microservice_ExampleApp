using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Modals;
using ProductCatalog.Modals.Entities;
using Xunit;

namespace ProductCatalog.Tests.Tests
{
    public class ProductServiceTests
    {
        private CatlogDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<CatlogDbContext>()
                .UseInMemoryDatabase(databaseName: "ProductDb_Test")
                .Options;
            return new CatlogDbContext(options);
        }

        [Fact]
        public void AddProduct_Should_Save_Product()
        {
            var context = GetDbContext();
            var product = new Product
            {
                Name = "Test Product",
                Price = 100,
                CategoryId = 1,
                Description = "Test Description",
                Sku = "SKU-123"
            };

            context.Products.Add(product);
            context.SaveChanges();

            var savedProduct = context.Products.FirstOrDefault();
            Assert.NotNull(savedProduct);
            Assert.Equal("Test Product", savedProduct.Name);
        }
    }
}
