using System;

namespace CarLot
{
    public class Validate
    {
        public static bool MatchPattern()
        {
            throw new NotImplementedException();
        }

        public static string InputString(string query, string input = "")
        {
            Console.Write($"Please enter a value for {query}: ");
            input = Console.ReadLine();

            //this is only validating for a string that isn't blank or null
            while (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                Console.Clear();
                Console.WriteLine($"That input was not correct for {query}");
                Console.Write($"Please enter a value for {query}: ");
                input = Console.ReadLine();
            }

            return input;
        }

        public static int InputInt(string query, int input = 0)
        {
            Console.Write($"Please enter a value for {query}: ");

            //this just validate for a number
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Clear();
                Console.WriteLine($"That input was not correct for {query}");
                Console.Write($"Please enter a value for {query}: ");
            }

            return input;
        }

        public static double InputDouble(string query, double input = 0)
        {
            Console.Write($"Please enter a value for {query}: ");

            //this just validates for a number
            while (!double.TryParse(Console.ReadLine(), out input))
            {
                Console.Clear();
                Console.WriteLine($"That input was not correct for {query}");
                Console.Write($"Please enter a value for {query}: ");
            }

            return input;
        }

        public static string OptionChoice()
        {
            string choice = Console.ReadLine();

            //this is only checking that the string is not null or blank and within a range
            while (string.IsNullOrEmpty(choice) || string.IsNullOrWhiteSpace(choice))
            {
                //this checks that input is a number
                if (!int.TryParse(choice, out int result))
                {
                    Console.Clear();
                    Console.WriteLine($"That input was not correct for Options");
                    CarLotPOS.Options();
                    choice = Console.ReadLine();
                }
                //this checks that if it's a number that is in a certain range
                else if (result < 1 || result > 4)
                {
                    Console.Clear();
                    Console.WriteLine($"That input was not correct for Options");
                    CarLotPOS.Options();
                    choice = Console.ReadLine();
                }
                //if it is a number and within the range then turn result into a string and hold that value in choice variable
                else
                {
                    choice = result.ToString();
                }
            }

            return choice;
        }

        public static string CarChoice()
        {
            string carChoice = "";
            bool keepTrying = true;
            while (keepTrying)
            {
                Console.WriteLine("Do you want to add a New or a Used car");
                carChoice = Console.ReadLine();
                if (carChoice.ToLower() != "used" || carChoice.ToLower() != "new")
                {
                    Console.WriteLine("That is not correct please make a choice of New or Used");
                }
                else
                {
                    keepTrying = false;
                }
            }

            return carChoice.ToLower();
        }
    }
}