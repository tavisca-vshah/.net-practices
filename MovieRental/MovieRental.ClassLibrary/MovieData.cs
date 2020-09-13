using System;

namespace MovieRental.ClassLibrary
{
    public class MovieData
    {
        private String movieTitle;
        private int priceCode;

        public MovieData(String title, int priceCode)
        {
            this.movieTitle = title;
            this.priceCode = priceCode;
        }

        public int getPriceCode()
        {
            return priceCode;
        }

        public void setPriceCode(int arg)
        {
            priceCode = arg;
        }

        public String getMovieTitle()
        {
            return movieTitle;
        }
    }
}
