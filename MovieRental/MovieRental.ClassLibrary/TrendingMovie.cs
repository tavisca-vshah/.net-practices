namespace MovieRental.ClassLibrary
{
    public class TrendingMovie : Movie
    {
        public TrendingMovie(string title) : base(title)
        {
        }

        public override double GetPrice(int daysRented)
        {
            double price = daysRented * 3;

            return price;
        }
    }
}
