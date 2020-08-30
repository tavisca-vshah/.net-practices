namespace MovieRental.ClassLibrary
{
    public class Rental
    {
        private readonly int _daysRented;
        private readonly Movie _movie;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return _daysRented;
        }

        public Movie GetMovie()
        {
            return _movie;
        }

        internal int GetFrquentRenterPoints()
        {
            return _movie.GetFrquentRenterPoints(_daysRented);
        }

        internal double GetCharge()
        {
            return _movie.GetCharge(_daysRented);
        }
    }
}