using System;
using System.Collections.Generic;
using System.Text;
using MovieRental.ClassLibrary;
using Xunit;

namespace MovieRental.Tests
{
    public class MovieRentalTests
    {
        [Fact]
        public void Customer_GenerateTextStatement()
        {
            Custmer customer = new Custmer("John Doe");

            customer.addRental(new Rental(new Movie("Harry Potter", 0), 4));
            customer.addRental(new Rental(new Movie("John Wick", 2), 10));
            customer.addRental(new Rental(new Movie("The Boult", 1), 20));

            string statement = customer.statement();

            Assert.Equal("Rental Record for John Doe\n" +
                    "\tHarry Potter\t5\n" +
                    "\tJohn Wick\t12\n" +
                    "\tThe Boult\t60\n" +
                    "Amount owed is 77\n" +
                    "You earned 4 frequent renter points", statement);
        }
    }
}
