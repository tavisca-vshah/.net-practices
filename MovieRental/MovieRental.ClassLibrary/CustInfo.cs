using System;
using System.Collections.Generic;

namespace MovieRental.ClassLibrary
{
    public class CustInfo
    {
        private string _custName;
        private readonly List<RentalDetails> _rentals = new List<RentalDetails>();

        public CustInfo(String name)
        {
            _custName = name;
        }

        public void AddRental(RentalDetails arg)
        {
            _rentals.Add(arg);
        }

        public string GetCustName()
        {
            return _custName;
        }

        public String Statement()
        {
            double temp = 0;
            int points = 0;
            String result = "Rental Record for " + GetCustName() + "\n";
            foreach (RentalDetails rd in _rentals)
            {
                double amt = 0;

                switch (rd.GetMovie().GetPriceCode())
                {
                    case 0: //常規電影 Chángguī diànyǐng
                        amt += 2;
                        if (rd.GetDaysRented() > 2)
                            amt += (rd.GetDaysRented() - 2) * 1.5;
                        break;

                    case 1:  // Film récemment sorti
                        amt += rd.GetDaysRented() * 3;
                        break;

                    case 2: //छोटे बच्चो की मूवीज
                        amt += 1.5;
                        if (rd.GetDaysRented() > 3)
                            amt += (rd.GetDaysRented() - 3) * 1.5;
                        break;
                }

                // add frequent renter points
                points++;

                // add bonus for a two day new release rental
                if ((rd.GetMovie().GetPriceCode() == 1)
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
