using System;

namespace MovieRental.ClassLibrary
{
    internal static class PriceFactory
    {
        internal static Price CreateFor(int priceCode)
        {
            switch (priceCode)
            {
                case Movie.Regular:
                    return new RegularPrice();

                case Movie.Childrens:
                    return new ChildrensPrice();

                case Movie.NewRelease:
                    return new NewReleasePrice();

                default:
                    throw new ArgumentException("Incorrect price code");
            }
        }
    }
}