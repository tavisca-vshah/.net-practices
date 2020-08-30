using System.Collections.Generic;

namespace MovieRental.ClassLibrary
{
    public class Customer
    {
        private readonly string _name;
        private List<Rental> rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public string GetCustName()
        {
            return _name;
        }

        public string TextStatement()
        {
            double temp = 0;
            int points = 0;
            string result = "Rental Record for " + GetCustName() + "\n";
            foreach (Rental rd in rentals)
            {
                double amt = 0;

                switch (rd.GetMovie().GetPriceCode())
                {
                    case 0: //常規電影 Chángguī diànyǐng
                        amt += 2;
                        if (rd.GetDaysRented() > 2)
                            amt += (rd.GetDaysRented() - 2) * 1.5;
                        break;

                    case 1:  // Film récemment sorti
                        amt += rd.GetDaysRented() * 3;
                        break;

                    case 2: //छोटे बच्चो की मूवीज
                        amt += 1.5;
                        if (rd.GetDaysRented() > 3)
                            amt += (rd.GetDaysRented() - 3) * 1.5;
                        break;
                }

                // add frequent renter points
                points++;

                // add bonus for a two day new release rental
                if ((rd.GetMovie().GetPriceCode() == 1)
                        &&
                        rd.GetDaysRented() > 1) points++;

                //show figures for this rental
                result += "\t" + rd.GetMovie().GetMovieTitle() + "\t" +
                        amt + "\n";
                temp += amt;
            }

            //add footer lines result
            result += "Amount owed is " + temp + "\n";
            result += "You earned " + points
                    + " frequent renter points";
            return result;
        }
    }

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
    }

    public class Movie
    {
        private readonly string _movieTitle;
        private int _priceCode;

        public Movie(string title, int priceCode)
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