using System;
using System.Collections.Generic;
using System.ComponentModel;

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
        //Todo: Decouple Text formatter task and Price compute O/p
        //Todo: check if Movie object can be replaced with its appropiate type
        public string TextStatement()
        {
            double temp = 0;
            int points = 0;
            //Todo : Replace String with StringBuilder because of performance hit
            string result = "Rental Record for " + GetName() + "\n";
            foreach (Rental rd in _rentals)
            {
                var amount = rd.GetMovie().GetPrice(rd.GetDaysRented());

                points += rd.GetPoints();
                //show figures for this rental
                result += "\t" + rd.GetMovie().GetMovieTitle() + "\t" +
                        amount + "\n";
                temp += amount;
            }

            //add footer lines result
            result += "Amount owed is " + temp + "\n";
            result += "You earned " + points
                    + " frequent renter points";
            return result;
        }
    }
}
