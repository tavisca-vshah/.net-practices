using System;

namespace MovieRental.ClassLibrary
{
    public class Movie
    {
        private readonly string _movieTitle;
        private MovieType _movieType;

        public Movie(string title, MovieType movieType)
        {
            Guard.Against.NullOrWhiteSpace(title, nameof(title));

            _movieTitle = title;
            _movieType = movieType;
        }

        public MovieType GetMovieType()
        {
            return _movieType;
        }

        public void SetMovieType(MovieType movieType)
        {
            _movieType = movieType;
        }

        public string GetMovieTitle()
        {
            return _movieTitle;
        }
    }
}
