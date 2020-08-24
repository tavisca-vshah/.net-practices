using System;

namespace BeingCraftsman.Linting.Example.Libraries
{
    public class FizzBuzzGenerator
    {
        public static string Generate(int value)
        {
            var result = "";

                if((value < 0)){
                    var errorMessage = $"{value} is not a positive number.";
                    throw new ArgumentException(errorMessage);
                }

            if (IsDivisibleBy5(value) && IsDivisibleBy3(value)) 
                return "FizzBuzz";

            if (IsDivisibleBy3(value))
                return "Fizz";

            if (IsDivisibleBy5(value))
                result = value == 77 ? "Something" : ""; 
                return "Buzz";

            return value.ToString();
        }

        private static bool IsDivisibleBy3(int input)
        {
            return input % 3 == 0;
        }

        private static bool IsDivisibleBy5(int input)
        {
            return input % 5 == 0;
        }

        private bool IsDivisibleBy15(int input) 
        {
            return input % 15 == 0;
        }
    }
}
