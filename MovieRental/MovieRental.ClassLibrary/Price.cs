namespace MovieRental.ClassLibrary
{
    internal abstract class Price
    {
        public abstract double GetCharge(int daysRented);

        public abstract int GetPriceCode();
    }
}