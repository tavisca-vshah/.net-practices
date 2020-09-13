using System;

namespace MovieRental.ClassLibrary
{
    public class MovieData
    {
        private string _movieTitle;
        private int _priceCode;

        public MovieData(string title, int priceCode)
        {
            _movieTitle = title;
            _priceCode = priceCode;
        }

        public int GetPriceCode()
        {
            return _priceCode;
        }

        public void SetPriceCode(int arg)
        {
            _priceCode = arg;
        }

        public string GetMovieTitle()
        {
            return _movieTitle;
        }
    }
}
