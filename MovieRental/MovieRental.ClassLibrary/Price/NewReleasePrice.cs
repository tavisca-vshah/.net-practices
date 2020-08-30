namespace MovieRental.ClassLibrary
{
    internal class NewReleasePrice : Price
    {
        public override double GetCharge(int daysRented)
        {
            return daysRented * 3;
        }

        public override int GetPriceCode()
        {
            return Movie.NewRelease;
        }
    }
}