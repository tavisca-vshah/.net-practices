﻿namespace MovieRental.ClassLibrary
{
    public class Rental
    {
        private int _daysRented;
        private Movie _movie;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return _daysRented;
        }

        public Movie GetMovie()
        {
            return _movie;
        }
    }
}
