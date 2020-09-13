namespace MovieRental.ClassLibrary
{
    public class RentalDetails
    {
        private int _daysRented;
        private MovieData _movie;

        public RentalDetails(MovieData movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return _daysRented;
        }

        public MovieData GetMovie()
        {
            return _movie;
        }
    }
}
