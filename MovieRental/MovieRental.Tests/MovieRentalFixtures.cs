using MovieRental.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MovieRental.Tests
{
    public class MovieRentalTests
    {
        [Fact]
        public void Customer_GenerateTextStatement()
        {
            var customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Harry Potter", MovieType.Regular), 4));
            customer.AddRental(new Rental(new Movie("John Wick", MovieType.LittleKids), 10));
            customer.AddRental(new Rental(new Movie("The Boult", MovieType.RecentlyReleased), 20));
            string statement = customer.TextStatement();
            Assert.Equal(
                "Rental Record for John Doe\n" +
                    "\tHarry Potter\t5\n" +
                    "\tJohn Wick\t12\n" +
                    "\tThe Boult\t60\n" +
                    "Amount owed is 77\n" +
                    "You earned 4 frequent renter points", statement);
        }
    }
}
