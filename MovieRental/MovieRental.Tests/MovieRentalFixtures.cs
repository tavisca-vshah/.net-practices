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
            customer.AddRental(new Rental(new RegularMovie("Harry Potter"), 4));
            customer.AddRental(new Rental(new KidsMovie("John Wick"), 10));
            customer.AddRental(new Rental(new TrendingMovie("The Boult"), 20));
            var textStatementFormatter = new TextStatementFormatter();
            var statement = textStatementFormatter.FormatCustomerDetails(customer);

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
