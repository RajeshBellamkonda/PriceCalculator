using PriceCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceCalculator.Offers
{
    public class PercentageOffer : IOffer
    {
        private decimal _offerPercentage;
        private IProduct _productOnOffer;
        private IProduct _conditionForOffer;

        public PercentageOffer(IProduct productOnOffer, IProduct conditionForOffer, decimal offerPercentage)
        {
            _productOnOffer = productOnOffer;
            _conditionForOffer = conditionForOffer;
            _offerPercentage = offerPercentage;
        }

        public decimal CalculateDiscount(IList<IProduct> basketProducts)
        {
            // 2 buter, 1 bread - bread 50%
            // 4 butter, 2 bread - 2 bread 50%
            var noOfBasketProductsOfferApplies = basketProducts.Where(p => p.Name == _productOnOffer.Name)
                .Sum(p => p.Quantity);
            if (noOfBasketProductsOfferApplies > 0 && noOfBasketProductsOfferApplies >= _productOnOffer.Quantity)
            {
                var noOfBasketProductsMatchingCondition = basketProducts.Where(p => p.Name == _conditionForOffer.Name)
                    .Sum(p => p.Quantity);

                if (noOfBasketProductsMatchingCondition >= _conditionForOffer.Quantity)
                {
                    var noOftimesToOfferDiscount = (noOfBasketProductsMatchingCondition / _conditionForOffer.Quantity);

                    if (noOfBasketProductsOfferApplies <= noOftimesToOfferDiscount)
                        noOftimesToOfferDiscount = noOftimesToOfferDiscount - (noOftimesToOfferDiscount - noOfBasketProductsOfferApplies);

                    var discountAmount = (_offerPercentage / 100) * _productOnOffer.Price;

                    return discountAmount * noOftimesToOfferDiscount;
                }
            }
            return 0;
        }

    }
}
