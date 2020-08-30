using System;

namespace MovieRental.ClassLibrary
{
    public class Movie
    {
        internal const int Childrens = 2;
        internal const int NewRelease = 1;
        internal const int Regular = 0;

        private Price _price;
        private readonly string _movieTitle;

        public Movie(string title, int priceCode)
        {
            _movieTitle = title;
            SetPriceCode(priceCode);
        }

        public string GetMovieTitle()
        {
            return _movieTitle;
        }

        public int GetPriceCode()
        {
            return _price.GetPriceCode();
        }

        internal int GetFrquentRenterPoints(int daysRented)
        {
            if ((GetPriceCode() == Movie.NewRelease) && daysRented > 1)
            {
                return 2;
            }

            return 1;
        }

        internal double GetCharge(int daysRented)
        {
            return _price.GetCharge(daysRented);
        }

        public void SetPriceCode(int priceCode)
        {
            switch (priceCode)
            {
                case Movie.Regular:
                    _price = new RegularPrice();
                    break;

                case Movie.Childrens:
                    _price = new ChildrensPrice();
                    break;

                case Movie.NewRelease:
                    _price = new NewReleasePrice();
                    break;

                default:
                    throw new ArgumentException("Incorrect price code");
            }
        }
    }
}