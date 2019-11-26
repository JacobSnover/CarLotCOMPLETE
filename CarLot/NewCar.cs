using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarLot
{
    //NewCar inherits from Car class
    //This means NewCar is derived from Car
    class NewCar : Car
    {
        #region constructors
        //this overloaded constructor is used when building objects from our CSV file
        public NewCar(string make, string model, int year)//pass in the necessary values
        {
            Make = make;
            Model = model;
            Year = year;
        }

        //make default constructor that calls to our overridden GetObject method which returns a Validated object
        //we use the this keyword which is referencing the caller object, which is the object that called the method
        public NewCar() { this.GetObject(); }
        #endregion


        #region method to display object as text
        //we will override our virtual method changing its functionality
        public override string Definition()
        {
            //we first call the base.Definition which was inherited from the Car class
            //then we also add the Make, Model, and Year members that were also inherited from the Car class
            return $"{base.Definition()} {Make,-15} {Model,-15} {Year,-4}";
        }
        #endregion

        #region methods to handle File I/O operations
        /// <summary>
        /// return string in CSV format
        /// </summary>
        /// <param name="car"></param>
        public static string CarToCSV(NewCar car)
        {
            //added the number 1 to the string to indicate a NewCar object
            return $"{1},{car.Make},{car.Model},{car.Year}";
        }

        /// <summary>
        /// return object from CSV line
        /// </summary>
        /// <param name="line"></param>
        public static NewCar CSVToCar(string line)
        {
            //first we split CSV into a new string array
            string[] csvArray = line.Split(',');
            //then return NewCar object to the caller
            return new NewCar(csvArray[1], csvArray[2], int.Parse(csvArray[3]));
        }
        #endregion


        #region method to Get a Valid Object
        //this method is called when a new car needs to be added to the list
        public override Car GetObject()
        {
            //List of Keys to control the object building process
            List<string> members = new List<string>() { "Make", "Model" };

            //iterate through members List created above, control the NewCaar object buuilding flow
            foreach (string member in members)
            {
                //first we grab the data for the Make member of the NewCar object
                if (member == "Make")
                {
                    this.Make = Validate.InputString(member);
                }
                else if (member == "Model")
                {
                    //second we grab the data for the Model member of the NewCar object
                    this.Model = Validate.InputString(member);
                }
                else
                {
                    //then we grab the data for the Year member of the NewCar object
                    this.Year = Validate.InputInt(member);
                }
            }
            //return the newly created valid object
            return this;
        }
        #endregion
    }
}