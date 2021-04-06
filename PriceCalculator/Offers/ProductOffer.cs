using PriceCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceCalculator.Offers
{
    public class ProductOffer : IOffer
    {
        private IProduct _offerProduct { get; }
        private decimal _offerAmount { get; }
        public ProductOffer(IProduct offerProduct, decimal offerAmount)
        {
            _offerProduct = offerProduct;
            _offerAmount = offerAmount;
        }

        public decimal CalculateDiscount(IList<IProduct> basketProducts)
        {
            var noOfBasketProductsOfferApplies = basketProducts.Where(x => x.Name == _offerProduct.Name)
                                                                .Sum(x => x.Quantity);

            if (noOfBasketProductsOfferApplies > 0 && noOfBasketProductsOfferApplies >= _offerProduct.Quantity)
            {
                return noOfBasketProductsOfferApplies / _offerProduct.Quantity * _offerAmount;
            }
            return 0;
        }

    }
}
