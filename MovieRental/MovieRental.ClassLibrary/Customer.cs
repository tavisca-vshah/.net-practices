using System.Collections.Generic;
using System.Linq;

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
            return _rentals.Sum((x) => x.GetCharge());
        }

        private int GetTotalFrequentRenterPoints()
        {
            return _rentals.Sum((x) => x.GetFrquentRenterPoints());
        }
    }
}