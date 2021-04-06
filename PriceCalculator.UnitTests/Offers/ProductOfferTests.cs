using NUnit.Framework;
using PriceCalculator.Interfaces;
using PriceCalculator.Offers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.UnitTests
{
    [TestFixture]
    public class ProductOfferTests
    {
        private ProductOffer _productOffer;

        [OneTimeSetUp]
        public void SetUp()
        {
            var productOnOffer = ProductFactory.CreateProduct(ProductType.Milk, 4);
            _productOffer = new ProductOffer(productOnOffer, productOnOffer.Price);
        }

        [TestCase(3, 0)]
        [TestCase(4, 1.15)]
        [TestCase(6, 1.15)]
        [TestCase(8, 2.30)]
        [TestCase(9, 2.30)]
        public void OneBreadGetsDiscount(int milkQuantity, decimal expectedDiscount)
        {
            var basketProducts = new List<IProduct>
            {
                ProductFactory.CreateProduct(ProductType.Butter, 3),
                ProductFactory.CreateProduct(ProductType.Bread, 2),
                ProductFactory.CreateProduct(ProductType.Milk, milkQuantity),
            };

            var discount = _productOffer.CalculateDiscount(basketProducts);

            Assert.AreEqual(expectedDiscount, discount);
        }

    }
}
