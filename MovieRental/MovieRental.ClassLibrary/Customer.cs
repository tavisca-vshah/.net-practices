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

        public List<Rental> GetRentals()
        {
            return _rentals;
        }
    }
}
