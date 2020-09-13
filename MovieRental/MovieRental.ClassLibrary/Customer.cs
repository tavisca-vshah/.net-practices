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
        public string TextStatement()
        {
            double temp = 0;
            int points = 0;
            string result = "Rental Record for " + GetName() + "\n";
            foreach (Rental rd in _rentals)
            {
                double amt = 0;

                switch (rd.GetMovie().GetMovieType())
                {
                    case MovieType.Regular:
                        amt += 2;
                        if (rd.GetDaysRented() > 2)
                            amt += (rd.GetDaysRented() - 2) * 1.5;
                        break;

                    case MovieType.RecentlyReleased:
                        amt += rd.GetDaysRented() * 3;
                        break;

                    case MovieType.LittleKids:
                        amt += 1.5;
                        if (rd.GetDaysRented() > 3)
                            amt += (rd.GetDaysRented() - 3) * 1.5;
                        break;
                }

                // add frequent renter points
                points++;

                // add bonus for a two day new release rental
                if ((rd.GetMovie().GetMovieType() == MovieType.RecentlyReleased)
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
}
