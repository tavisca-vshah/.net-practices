using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MovieRental.ClassLibrary
{
    public class Customer
    {
        private readonly string _name;
        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            _name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string GetName()
        {
            return _name;
        }

        //Todo: Remove this from here and create Interface for Statement Formatter
        public string TextStatement()
        {
            double temp = 0;
            int points = 0;

            var result = new StringBuilder("Rental Record for " + GetName() + "\n");

            foreach (Rental rd in _rentals)
            {
                var amount = rd.GetMovie().GetPrice(rd.GetDaysRented());

                points += rd.GetPoints();
                //show figures for this rental
                result.Append("\t" + rd.GetMovie().GetMovieTitle() + "\t" + amount + "\n");
                temp += amount;
            }

            //add footer lines result
            result.Append("Amount owed is " + temp + "\n");
            result.Append("You earned " + points + " frequent renter points");

            return result.ToString();
        }
    }
}
