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
            int frequentRenterPoints = 0;

            foreach (Rental rental in _rentals)
            {
                // add frequent renter points
                frequentRenterPoints++;

                // add bonus for a two day new release rental
                if ((rental.GetMovie().GetPriceCode() == 1)
                        &&
                        rental.GetDaysRented() > 1)
                {
                    frequentRenterPoints++;
                }
            }

            return frequentRenterPoints;
        }
    }

    public class Rental
    {
        private const int Childrens = 2;
        private const int NewRelease = 1;
        private const int Regular = 0;

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

        internal double GetCharge()
        {
            double rentalCharge = 0;

            switch (GetMovie().GetPriceCode())
            {
                case Regular:
                    rentalCharge += 2;
                    if (GetDaysRented() > 2)
                    {
                        rentalCharge += (GetDaysRented() - 2) * 1.5;
                    }

                    break;

                case NewRelease:
                    rentalCharge += GetDaysRented() * 3;
                    break;

                case Childrens:
                    rentalCharge += 1.5;
                    if (GetDaysRented() > 3)
                    {
                        rentalCharge += (GetDaysRented() - 3) * 1.5;
                    }

                    break;
            }

            return rentalCharge;
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

        public void SetPriceCode(int priceCode)
        {
            _priceCode = priceCode;
        }

        public string GetMovieTitle()
        {
            return _movieTitle;
        }
    }
}