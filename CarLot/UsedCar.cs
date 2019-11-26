using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarLot
{
    //made a UsedCar class, we will inherit our abstract Car class
    //making UsedCar derived from Car
    class UsedCar : Car
    {
        #region member that only belongs to this object, has not been inherited
        //make a private field to hold our data
        private double mileage;

        //make a public property to access our private field
        public double Mileage
        {
            //get method will return specified field
            get { return mileage; }
            //set method allows us to set our private field outside this class
            set { mileage = value; }
        }
        #endregion


        #region constructors
        //this overloaded constructor is used when building objects from the CSV file
        public UsedCar(string make, string model, int year, double mileage)
        {
            Make = make;
            Model = model;
            Year = year;
            Mileage = mileage;
        }

        //make default constructor that calls to our overridden GetObject method which returns a Validated object
        //we use the this keyword which is referencing the caller object, which is the object that called the method
        public UsedCar() { this.GetObject(); }
        #endregion


        #region method to display object as text
        //override our Definition virtual method
        public override string Definition()
        {
            //we first call the base.Definition which was inherited from the Car class
            //then we also add the Make, Model, and Year members that were also inherited from the Car class
            //lastly we add the Mileage member that pertains only to the UsedCar class
            return $"{base.Definition()} {Make,-15} {Model,-15} {Year,-4} {Mileage,-20}";
        }
        #endregion


        #region method to handle File I/O
        /// <summary>
        /// return string in CSV format
        /// </summary>
        /// <param name="car"></param>
        public static string CarToCSV(UsedCar car)
        {
            //added a number 2 to the string to indicate a UsedCar object
            return $"{2},{car.Make},{car.Model},{car.Year},{car.Mileage}";
        }

        /// <summary>
        /// return object from CSV line
        /// </summary>
        /// <param name="line"></param>
        public static UsedCar CSVToCar(string line)
        {
            //first we split CSV into a new string array
            string[] csvArray = line.Split(',');
            //then return NewCar object to the caller
            return new UsedCar(csvArray[1], csvArray[2], int.Parse(csvArray[3]), double.Parse(csvArray[4]));
        }
        #endregion


        #region method the Gets a Valid Object
        //this method will build a valid UsedCar objecct and return it
        public override Car GetObject()
        {
            //List of Keys to control the object building process
            List<string> members = new List<string>() { "Make", "Model", "Year" };

            //iterate through members List created above, control the NewCaar object buuilding flow
            foreach (string member in members)
            {
                //first we grab the data for the Make member of the UsedCar object
                if (member == "Make")
                {
                    this.Make = Validate.InputString(member);
                }
                else if (member == "Model")
                {
                    //second we grab the data for the Model member of the UsedCar object
                    this.Model = Validate.InputString(member);
                }
                else if (member == "Year")
                {
                    //third we grab the data for the Year member of the UsedCar object
                    this.Year = Validate.InputInt(member);
                }
                else
                {
                    //last we grab the data for the Mileage member of the UsedCar object
                    this.Mileage = Validate.InputDouble(member);
                }
            }
            //return the newly created valid object
            return this;
        }
        #endregion
    }
}