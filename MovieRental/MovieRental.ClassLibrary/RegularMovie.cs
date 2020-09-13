namespace MovieRental.ClassLibrary
{
    public class RegularMovie : Movie
    {
        public RegularMovie(string title) : base(title)
        {
        }

        public override double GetPrice(int daysRented)
        {
            double price = 2;
            if (daysRented > 2)
                price += (daysRented - 2) * 1.5;

            return price;
        }
    }
}
