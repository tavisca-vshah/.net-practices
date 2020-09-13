namespace MovieRental.ClassLibrary
{
    public class Rental
    {
        private readonly int _daysRented;
        private readonly Movie _movie;

        public Rental(Movie movie, int daysRented)
        {
            Guard.Against.Null(movie, nameof(movie));
            Guard.Against.LessThanZero(daysRented, nameof(daysRented));

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

        private bool IsEligibleForBonus()
        {
            var isTrendingMovie = GetMovie() is TrendingMovie;
            var isNumberOfDaysRentedGreaterThanOne = GetDaysRented() > 1;
            return isTrendingMovie && isNumberOfDaysRentedGreaterThanOne;
        }

        public int GetPoints()
        {
            return IsEligibleForBonus() ? 2 : 1;
        }
    }
}
