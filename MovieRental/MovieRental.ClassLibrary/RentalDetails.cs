namespace MovieRental.ClassLibrary
{
    public class RentalDetails
    {
        private int daysRented;
        private MovieData movie;

        public RentalDetails(MovieData movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public int getDaysRented()
        {
            return daysRented;
        }

        public MovieData getMovie()
        {
            return movie;
        }
    }
}