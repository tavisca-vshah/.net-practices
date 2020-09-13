using System;

namespace MovieRental.ClassLibrary
{
    public abstract class Movie
    {
        private readonly string _movieTitle;

        public Movie(string title)
        {
            Guard.Against.NullOrWhiteSpace(title, nameof(title));

            _movieTitle = title;
        }

        public string GetMovieTitle()
        {
            return _movieTitle;
        }

        public abstract double GetPrice(int daysRented);
    }
}
