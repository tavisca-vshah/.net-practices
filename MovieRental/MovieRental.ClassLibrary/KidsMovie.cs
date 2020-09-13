namespace MovieRental.ClassLibrary
{
    public class KidsMovie : Movie
    {
        public KidsMovie(string title) : base(title)
        {
        }

        public override double GetPrice(int daysRented)
        {
            double price = 1.5;
            if (daysRented > 3)
                price += (daysRented - 3) * 1.5;

            return price;
        }
    }
}
