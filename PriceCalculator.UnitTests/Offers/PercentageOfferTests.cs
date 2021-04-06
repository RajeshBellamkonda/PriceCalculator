using NUnit.Framework;
using PriceCalculator.Interfaces;
using PriceCalculator.Offers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.UnitTests
{
    [TestFixture]
    public class PercentageOfferTests
    {
        private PercentageOffer _percentageOffer;

        [OneTimeSetUp]
        public void SetUp()
        {
            var productOnOffer = ProductFactory.CreateProduct(ProductType.Bread, 1);
            var conditionForOffer = ProductFactory.CreateProduct(ProductType.Butter, 2);
            _percentageOffer = new PercentageOffer(productOnOffer, conditionForOffer, 50);
        }

        [TestCase(2, 1, 0.5)]
        [TestCase(3, 1, 0.5)]
        [TestCase(3, 2, 0.5)]
        [TestCase(4, 2, 1)]
        [TestCase(6, 2, 1)]
        [TestCase(8, 3, 1.5)]
        [TestCase(8, 4, 2)]
        public void OneBreadGetsDiscount(int butterQuantity, int breadQuantity, decimal expectedDiscount)
        {
            var basketProducts = new List<IProduct>
            {
                ProductFactory.CreateProduct(ProductType.Butter, butterQuantity),
                ProductFactory.CreateProduct(ProductType.Bread, breadQuantity),
                ProductFactory.CreateProduct(ProductType.Milk, 4),
            };

            var discount = _percentageOffer.CalculateDiscount(basketProducts);

            Assert.AreEqual(expectedDiscount, discount);
        }

    }
}
