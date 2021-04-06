using NUnit.Framework;
using PriceCalculator.Interfaces;
using PriceCalculator.Offers;
using System.Collections.Generic;

namespace PriceCalculator.UnitTests
{
    [TestFixture]
    public class BasketTests
    {
        private IBasket _basket;

        [OneTimeSetUp]
        public void Setup()
        {
            var percentageProductOnOffer = ProductFactory.CreateProduct(ProductType.Bread, 1);
            var conditionForOffer = ProductFactory.CreateProduct(ProductType.Butter, 2);
            var percentageOffer = new PercentageOffer(percentageProductOnOffer, conditionForOffer, 50);

            var productOnOffer = ProductFactory.CreateProduct(ProductType.Milk, 4);
            var productOffer = new ProductOffer(productOnOffer, productOnOffer.Price);

            var offers = new List<IOffer>
            {
                percentageOffer,
                productOffer
            };

            _basket = new Basket(offers);
        }

        [Test(Description = "GIVEN the basket has  1 bread, 1 butter and 1 milk WHEN I total the basket THEN the total should be £2.95")]
        public void BasketTotalShouldBe295()
        {
            // Arrange
            var basketProducts = new List<IProduct>
            {
                ProductFactory.CreateProduct(ProductType.Bread),
                ProductFactory.CreateProduct(ProductType.Butter),
                ProductFactory.CreateProduct(ProductType.Milk),
            };
            _basket.AddProducts(basketProducts);
            var expectedTotal = 2.95;

            // Act
            var basketTotal = _basket.Total();

            // Assert
            Assert.AreEqual(expectedTotal, basketTotal);
        }

        [Test(Description = "GIVEN the basket has 2 butter and 2 bread WHEN I total the basket THEN the total should be £3.10")]
        public void BasketTotalShouldBe310()
        {
            // Arrange
            var basketProducts = new List<IProduct>
            {
                ProductFactory.CreateProduct(ProductType.Bread,2),
                ProductFactory.CreateProduct(ProductType.Butter,2)
            };
            _basket.AddProducts(basketProducts);
            var expectedTotal = 3.10;

            // Act
            var basketTotal = _basket.Total();

            // Assert
            Assert.AreEqual(expectedTotal, basketTotal);
        }

        [Test(Description = "GIVEN the basket has 4 milk WHEN I total the basket THEN the total should be £3.45")]
        public void BasketTotalShouldBe345()
        {
            // Arrange
            var basketProducts = new List<IProduct>
            {
                ProductFactory.CreateProduct(ProductType.Milk,4)
            };
            _basket.AddProducts(basketProducts);
            var expectedTotal = 3.45;

            // Act
            var basketTotal = _basket.Total();

            // Assert
            Assert.AreEqual(expectedTotal, basketTotal);
        }

        [Test(Description = "GIVEN the basket has 2 butter, 1 bread and 8 milk WHEN I total the basket THEN the total should be £9.00")]
        public void BasketTotalShouldBe900()
        {
            // Arrange
            var basketProducts = new List<IProduct>
            {
                ProductFactory.CreateProduct(ProductType.Bread,1),
                ProductFactory.CreateProduct(ProductType.Butter,2),
                ProductFactory.CreateProduct(ProductType.Milk,8),
            };
            _basket.AddProducts(basketProducts);
            var expectedTotal = 9.00;

            // Act
            var basketTotal = _basket.Total();

            // Assert
            Assert.AreEqual(expectedTotal, basketTotal);
        }

    }
}
