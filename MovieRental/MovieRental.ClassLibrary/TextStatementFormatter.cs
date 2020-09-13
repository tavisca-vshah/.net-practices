using System;
using System.Text;

namespace MovieRental.ClassLibrary
{
    public class TextStatementFormatter : IStatementFormatter
    {
        public string FormatCustomerDetails(Customer customer)
        {
            double temp = 0;
            int points = 0;

            var result = new StringBuilder("Rental Record for " + customer.GetName() + "\n");

            foreach (Rental rd in customer.GetRentals())
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
