using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarLot
{
    class CarLotPOS
    {
        #region static inventory
        //static List of car objects is used to hold the most current inventory
        //allowing us to disply this whenever needed, also cutting down on queies to the CSV file
        private static List<Car> currentInventory { get; } = new List<Car>();
        #endregion


        #region StartUp
        /// <summary>
        /// StartUp method to prepare the CarLot POS
        /// </summary>
        public static void StartCarLotPOS()
        {
            GetCurrentInventory();
            MainMenu();
        }
        #endregion

        //Get method that will pull in the current inventory from the CSV file
        private static void GetCurrentInventory()
        {
            //first point the StreamReader object at the text file that holds the current inventory in CSV format
            StreamReader sr = new StreamReader(@"C:\Users\ShaKy\Source\Repos\CarLotCOMPLETE\CarLot\CarLotDB.txt");

            //string array to hold the split CSV row before parsing into necessary Car object
            string[] csvArray;

            //string that grabs and holds the first line of the CSV text file
            string line = sr.ReadLine();

            //while loop to iterate through the text file of CSV's building inventory List
            while (line != null)//as long as the first line of the text file is not null then continue with parsing
            {
                //spilt the CSV on the comma's until we have the sparate values indexed in our string array
                csvArray = line.Split(',');

                //check to see what type of Car object is in each CSV
                if (csvArray[0] == "1")//if it starts with a number 1 then it will be a NewCar object
                {
                    //we add a NewCar object passing a CSV string in to our method which returns a new object
                    currentInventory.Add(NewCar.CSVToCar(line));
                }
                else
                {
                    //we add a UsedCar object passing a CSV string in to our method which returns a new object
                    currentInventory.Add(UsedCar.CSVToCar(line));
                }

                //we advance the CSV text file to the next row of data
                line = sr.ReadLine();
            }

            //close the text file when done with File I/O operations
            sr.Close();
        }

        //method to Save/Update the current inventory
        private static void SaveCurrentInventory()
        {
            //create new streamwriter object
            StreamWriter sw = new StreamWriter(@"..\CarLotCOMPLETE\CarLot\CarLotDB.txt");

            //iterate through our list of cars and first make CSV string out of the objects data, and then write that data to the CSV text file
            foreach (Car car in currentInventory)
            {
                //check if the object is a NewCar or a UsedCar
                if (car is NewCar)
                {
                    //if its a NewCar then we call the method that is in the NewCar class
                    sw.WriteLine(NewCar.CarToCSV((NewCar)car));
                }
                else
                {
                    //if it is a UsedCar then we call then methiod that is in the UsedCar class
                    sw.WriteLine(UsedCar.CarToCSV((UsedCar)car));
                }
            }

            //closed the connection saving data to the text file
            sw.Close();
        }

        //method to display the MainMenu to navigate through the application
        private static void MainMenu()
        {
            //establish a bool to control program loop flow
            bool continueProgram = true;

            //while loop to control program flow
            while (continueProgram)
            {
                //display the Options menu for the User
                Options();

                //make a string variable that will hold the Users Choice
                string userChoice = Validate.OptionChoice();

                if(userChoice.ToLower() == "quit" || userChoice == "4")
                {
                    SaveCurrentInventory();
                    continueProgram = false;
                }
                else if (userChoice == "1")
                {
                    DisplsyCurrentInventory();
                }
                else if (userChoice == "2")
                {
                    //ask the User if they want to add a NewCar or a UsedCar
                    string carChoice = Validate.CarChoice();
                    if(carChoice == "new")
                    {
                        currentInventory.Add(new NewCar());
                    }
                    else
                    {
                        currentInventory.Add(new UsedCar());
                    }
                }
                else if (userChoice == "3")
                {
                    //check for admin
                    Console.Write("This is for system admins only!! Enter your admin password: ");
                    if(Console.ReadLine() == "1234")
                    {
                        //display list of cars
                        //find which car to remove
                        //remove that car
                    }
                }

            }
        }


        //method that will display list of current CarLot inventory
        private static void DisplsyCurrentInventory()
        {
            //iterate through the static List of cars
            foreach (Car car in currentInventory)
            {
                //display the information to the user
                Console.WriteLine(car.Definition());
            }
        }

        public static void Options()
        {
            //make a simple menu with options for the User
            Console.WriteLine("Welcome to Jacob's CarLot!!  Please make a selection from the menu below.");
            Console.WriteLine("1. Display Current Inventory");
            Console.WriteLine("2. Add new Car to the CarLot");
            Console.WriteLine("3. Remove Car from CarLot");
            Console.WriteLine("4. Type quit to exit program");
        }
    }

}
