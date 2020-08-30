using System;
using System.Collections.Generic;

namespace MovieRental.ClassLibrary
{
    public class Custmer
    {
        private String cust_name;
        private List<Rental> rentals = new List<Rental>();

        public Custmer(String name)
        {
            this.cust_name = name;
        }

        public void AddRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public String GetCustName()
        {
            return cust_name;
        }

        public String TextStatement()
        {
            double temp = 0;
            int points = 0;
            String result = "Rental Record for " + GetCustName() + "\n";
            foreach (Rental rd in rentals)
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

    public class Rental
    {
        private int daysRented;
        private Movie movie;

        public Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return daysRented;
        }

        public Movie GetMovie()
        {
            return movie;
        }
    }

    public class Movie
    {
        private String movieTitle;
        private int priceCode;

        public Movie(String title, int priceCode)
        {
            this.movieTitle = title;
            this.priceCode = priceCode;
        }

        public int GetPriceCode()
        {
            return priceCode;
        }

        public void SetPriceCode(int arg)
        {
            priceCode = arg;
        }

        public String GetMovieTitle()
        {
            return movieTitle;
        }
    }
}