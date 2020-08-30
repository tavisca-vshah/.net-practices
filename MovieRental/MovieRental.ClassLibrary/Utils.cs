using System;
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

    internal abstract class Price
    {
        public abstract double GetCharge(int daysRented);

        public abstract int GetPriceCode();
    }

    internal class ChildrensPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Childrens;
        }

        public override double GetCharge(int daysRented)
        {
            double amount = 1.5;
            if (daysRented > 3)
            {
                amount += (daysRented - 3) * 1.5;
            }
            return amount;
        }
    }

    internal class NewReleasePrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.NewRelease;
        }

        public override double GetCharge(int daysRented)
        {
            return daysRented * 3;
        }
    }

    internal class RegularPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Regular;
        }

        public override double GetCharge(int daysRented)
        {
            var amount = 2.0;

            if (daysRented > 2)
            {
                amount += (daysRented - 2) * 1.5;
            }

            return amount;
        }
    }
}