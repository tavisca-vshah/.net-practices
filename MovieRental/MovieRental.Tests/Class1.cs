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
            CustInfo customer = new CustInfo("John Doe");

            customer.addRental(new RentalDetails(new MovieData("Harry Potter", 0), 4));
            customer.addRental(new RentalDetails(new MovieData("John Wick", 2), 10));
            customer.addRental(new RentalDetails(new MovieData("The Boult", 1), 20));

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
