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
            string statement = $"Rental Record for {GetCustomerName()}\n";

            foreach (Rental rental in _rentals)
            {
                statement += $"\t{rental.GetMovie().GetMovieTitle()}\t{rental.GetCharge()}\n";
            }

            // add footer lines result
            statement += $"Amount owed is {GetTotalAmount()}\n";
            statement += $"You earned {GetTotalFrequentRenterPoints()} frequent renter points";
            return statement;
        }

        private double GetTotalAmount()
        {
            double totalAmount = 0;

            foreach (Rental rental in _rentals)
            {
                totalAmount += rental.GetCharge();
            }

            return totalAmount;
        }

        private int GetTotalFrequentRenterPoints()
        {
            int totalFrequentRenterPoints = 0;

            foreach (Rental rental in _rentals)
            {
                totalFrequentRenterPoints += rental.GetFrquentRenterPoints();
            }

            return totalFrequentRenterPoints;
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

        internal int GetFrquentRenterPoints()
        {
            return _movie.GetFrquentRenterPoints(_daysRented);
        }

        internal double GetCharge()
        {
            return _movie.GetCharge(_daysRented);
        }
    }

    public class Movie
    {
        private const int Childrens = 2;
        private const int NewRelease = 1;
        private const int Regular = 0;

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

        public void SetPriceCode(int priceCode)
        {
            _priceCode = priceCode;
        }

        public string GetMovieTitle()
        {
            return _movieTitle;
        }

        internal int GetFrquentRenterPoints(int daysRented)
        {
            int frequentRenterPoints = 0;

            // add frequent renter points
            frequentRenterPoints++;

            // add bonus for a two day new release rental
            if ((GetPriceCode() == 1) && daysRented > 1)
            {
                frequentRenterPoints++;
            }

            return frequentRenterPoints;
        }

        internal double GetCharge(int daysRented)
        {
            double rentalCharge = 0;

            switch (GetPriceCode())
            {
                case Regular:
                    rentalCharge += 2;
                    if (daysRented > 2)
                    {
                        rentalCharge += (daysRented - 2) * 1.5;
                    }

                    break;

                case NewRelease:
                    rentalCharge += daysRented * 3;
                    break;

                case Childrens:
                    rentalCharge += 1.5;
                    if (daysRented > 3)
                    {
                        rentalCharge += (daysRented - 3) * 1.5;
                    }

                    break;
            }

            return rentalCharge;
        }
    }
}