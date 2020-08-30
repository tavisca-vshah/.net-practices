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

        public void addRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public String getCustName()
        {
            return cust_name;
        }

        public String statement()
        {
            double temp = 0;
            int points = 0;
            String result = "Rental Record for " + getCustName() + "\n";
            foreach (Rental rd in rentals)
            {
                double amt = 0;

                switch (rd.getMovie().getPriceCode())
                {
                    case 0: //常規電影 Chángguī diànyǐng
                        amt += 2;
                        if (rd.getDaysRented() > 2)
                            amt += (rd.getDaysRented() - 2) * 1.5;
                        break;

                    case 1:  // Film récemment sorti
                        amt += rd.getDaysRented() * 3;
                        break;

                    case 2: //छोटे बच्चो की मूवीज 
                        amt += 1.5;
                        if (rd.getDaysRented() > 3)
                            amt += (rd.getDaysRented() - 3) * 1.5;
                        break;
                }

                // add frequent renter points
                points++;
                
                // add bonus for a two day new release rental
                if ((rd.getMovie().getPriceCode() == 1)
                        &&
                        rd.getDaysRented() > 1) points++;

                //show figures for this rental
                result += "\t" + rd.getMovie().getMovieTitle() + "\t" +
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

        public int getDaysRented()
        {
            return daysRented;
        }

        public Movie getMovie()
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

        public int getPriceCode()
        {
            return priceCode;
        }

        public void setPriceCode(int arg)
        {
            priceCode = arg;
        }

        public String getMovieTitle()
        {
            return movieTitle;
        }
    }
}