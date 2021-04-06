using NUnit.Framework;
using System;

namespace PriceCalculator.UnitTests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void ProductQuantityHasCorrectValue()
        {
            // Arrange
            // Act
            var products = ProductFactory.CreateProduct(ProductType.Butter, 2);

            // Assert
            Assert.AreEqual(2, products.Quantity);
        }

        [Test]
        public void InvalidProductQuantityThrowsException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => ProductFactory.CreateProduct(ProductType.Milk, 0));
        }

        [TestCase(ProductType.Butter, 2, 1.6)]
        [TestCase(ProductType.Milk, 3, 3.45)]
        [TestCase(ProductType.Bread, 4, 4)]
        public void ShouldHaveCorrectTotal(ProductType productType, int quantity, decimal expectedTotal)
        {
            // Arrange
            // Act
            var products = ProductFactory.CreateProduct(productType, quantity);

            // Assert
            Assert.AreEqual(expectedTotal, products.Total);
        }
    }
}