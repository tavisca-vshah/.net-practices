namespace MovieRental.ClassLibrary
{
    internal class RegularPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Regular;
        }

        public override double GetCharge(int daysRented)
        {
            var amount = 2.0;

            if (daysRented > 2)
            {
                amount += (daysRented - 2) * 1.5;
            }

            return amount;
        }
    }
}