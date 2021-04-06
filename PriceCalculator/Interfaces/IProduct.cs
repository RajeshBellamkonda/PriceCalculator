namespace PriceCalculator.Interfaces
{
    public interface IProduct
    {
        string Name { get; }
        int Quantity { get; }
        decimal Price { get; }

        decimal Total { get; }

        void AddQuantity(int quantity);
    }
}