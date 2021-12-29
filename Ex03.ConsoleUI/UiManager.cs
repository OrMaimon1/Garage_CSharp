using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A22_Ex03_01;

namespace Ex03.ConsoleUI
{
    class UiManager
    {
        private Garage m_Garage;

        public UiManager()
        {
            m_Garage = new Garage();
        }
        private Garage Garage
        {
            get
            {
                return m_Garage;
            }
        }

        public void AddVehicle()
        {
            Console.WriteLine("Enter the license number of the vehicle (7 digits)");
            string licenseNumber = Console.ReadLine();
            if(Garage.VehicleExists(licenseNumber))
            {
                Garage.AddExistingVehicle(licenseNumber);
            }
            else
            {
                Console.WriteLine("Please choose vehicle type: ");
                //Need  To Create menu of types to choose from
                string vehicleType = Console.ReadLine();
                //Enum.TryParse(Console.ReadLine(), out vehicleType);
                Vehicle vehicle = VehicleFactory.CreateVehicle(vehicleType, licenseNumber);

                Hashtable UniqueInfoOfVehicle = vehicle.FetchUniqueInfo();

                foreach(KeyValuePair<string , string> infoToFill in UniqueInfoOfVehicle)
                {
                    vehicle.UpdateUniqueInfo(infoToFill.Key , Console.ReadLine());
                }



            }
        }



        public void EnteringGeneralInfo(Garage.VehicleInGarage i_VehicleInGarage)
        {
            string fullName = string.Empty;
            string phoneNumber = string.Empty;
            string modelName = string.Empty;
            float energySourceLeft = 0;
            string manufactureOfTheWheels = string.Empty;

            Console.WriteLine("Please enter your name: ");
            fullName = Console.ReadLine();
            ValidateThatTheInputIsNotEmpty(fullName);
            Console.WriteLine("Please enter your phone number: ");
            phoneNumber = Console.ReadLine();
            ValidateThatTheInputIsNotEmpty(phoneNumber);
            Console.WriteLine("Please enter the model of the vehicle: ");
            modelName = Console.ReadLine();
            ValidateThatTheInputIsNotEmpty(modelName);
            Console.WriteLine("Please enter the manufacture of the wheels: ");
            ValidateThatTheInputIsNotEmpty(energySourceLeft); /// added need to check
            Console.WriteLine("Please enter the manufacture of the wheels: ");
            manufactureOfTheWheels = Console.ReadLine();
            ValidateThatTheInputIsNotEmpty(manufactureOfTheWheels);
            m_Garage.AddGeneralInfo(i_VehicleInGarage, fullName, phoneNumber, modelName);
            i_VehicleInGarage.CurrentVehicle.InsertManufactureName(manufactureOfTheWheels);
        }

    }
}
