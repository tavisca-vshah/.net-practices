namespace MovieRental.ClassLibrary
{
    internal class ChildrensPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Childrens;
        }

        public override double GetCharge(int daysRented)
        {
            double amount = 1.5;
            if (daysRented > 3)
            {
                amount += (daysRented - 3) * 1.5;
            }
            return amount;
        }
    }
}