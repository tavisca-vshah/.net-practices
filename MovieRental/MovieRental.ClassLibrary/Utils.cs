using System.Collections.Generic;

namespace MovieRental.ClassLibrary
{
    public class Customer
    {
        private readonly string _name;
        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public string GetCustomerName()
        {
            return _name;
        }

        public string TextStatement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string statement = "Rental Record for " + GetCustomerName() + "\n";
            foreach (Rental rental in _rentals)
            {
                double rentalCharge = 0;

                switch (rental.GetMovie().GetPriceCode())
                {
                    case 0: //常規電影 Chángguī diànyǐng
                        rentalCharge += 2;
                        if (rental.GetDaysRented() > 2)
                            rentalCharge += (rental.GetDaysRented() - 2) * 1.5;
                        break;

                    case 1:  // Film récemment sorti
                        rentalCharge += rental.GetDaysRented() * 3;
                        break;

                    case 2: //छोटे बच्चो की मूवीज
                        rentalCharge += 1.5;
                        if (rental.GetDaysRented() > 3)
                            rentalCharge += (rental.GetDaysRented() - 3) * 1.5;
                        break;
                }

                // add frequent renter points
                frequentRenterPoints++;

                // add bonus for a two day new release rental
                if ((rental.GetMovie().GetPriceCode() == 1)
                        &&
                        rental.GetDaysRented() > 1) frequentRenterPoints++;

                //show figures for this rental
                statement += "\t" + rental.GetMovie().GetMovieTitle() + "\t" +
                        rentalCharge + "\n";
                totalAmount += rentalCharge;
            }

            //add footer lines result
            statement += "Amount owed is " + totalAmount + "\n";
            statement += "You earned " + frequentRenterPoints
                    + " frequent renter points";
            return statement;
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