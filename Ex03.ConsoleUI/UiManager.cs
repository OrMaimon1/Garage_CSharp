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
                VehicleInGarage vehicleInGarage = new VehicleInGarage();
                vehicleInGarage.Vehicle = vehicle;
                EnteringGeneralInfo(vehicleInGarage);
                Hashtable UniqueInfoOfVehicle = vehicle.FetchUniqueInfo();
                foreach(KeyValuePair<string , string> infoToFill in UniqueInfoOfVehicle)
                {
                    Console.WriteLine(infoToFill.Key);
                    vehicle.UpdateUniqueInfo(infoToFill.Key , Console.ReadLine());
                }
            }
        }
        public void EnteringGeneralInfo(VehicleInGarage i_VehicleInGarage)
        {
            string fullName = string.Empty;
            string phoneNumber = string.Empty;
            string modelName = string.Empty;
            float energySourceLeft = i_VehicleInGarage.Vehicle.Engine.EnergySourceLeft / i_VehicleInGarage.Vehicle.Engine.MaxEnergySource;
            string manufactureOfTheWheels = string.Empty;

            Console.WriteLine("Please enter your name: ");
            fullName = Console.ReadLine();
            InputIsNotEmpty(fullName);
            Console.WriteLine("Please enter your phone number: ");
            phoneNumber = Console.ReadLine();
            InputIsNotEmpty(phoneNumber);
            Console.WriteLine("Please enter the model of the vehicle: ");
            modelName = Console.ReadLine();
            InputIsNotEmpty(modelName);
            Console.WriteLine("Please enter the manufacture of the wheels: ");
            ValidateThatTheInputIsNotEmpty(energySourceLeft); /// added need to check
            Console.WriteLine("Please enter the manufacture of the wheels: ");
            manufactureOfTheWheels = Console.ReadLine();
            InputIsNotEmpty(manufactureOfTheWheels);
            m_Garage.AddGeneralInfo(i_VehicleInGarage, fullName, phoneNumber, modelName);
            i_VehicleInGarage.CurrentVehicle.InsertManufactureName(manufactureOfTheWheels);
        }

        
        public void UpdateVehicleState()
        {
            Console.WriteLine("Please choose the license number of the vehicle you wish to update");
            //Need to validate license input
            string licenseNumber = Console.ReadLine();
            Console.WriteLine("Please choose the new state of the vehicle: ");
            //Need to creaate a menu for vehicle states
            string userChoice = Console.ReadLine();
            eVehicleState vehicleState;
            Enum.TryParse(userChoice, out vehicleState);
            Garage.UpdateVehicleState(licenseNumber , vehicleState);
        }

        public void ViewVehicleLicense()
        {
            eVehicleState vehicleState;
            Console.WriteLine("Please choose which Licenses you wish to view");
            //Need to create a menu for Vehicle state
            Enum.TryParse(Console.ReadLine(), out vehicleState);
            List<string> licensesToView = Garage.ShowListOfLicenses(vehicleState);
            foreach(string license in licensesToView)
            {
                Console.WriteLine(license);
            }
        }

        public void InflateWheelsToMax()
        {
            Console.WriteLine("Please enter license number of the vehicle you wish to work on: ");
            string licenseNumber = Console.ReadLine();
            //Need to validate license number
            Garage.InflateWheelsToMaximumPressure(licenseNumber);
        }

        public void FuelVehicle()
        {
            Console.WriteLine("Please enter license number of the vehicle you wish to fuel: ");
            string licenseNumber = Console.ReadLine();
            while(!Garage.VehicleExists(licenseNumber))
            {
                licenseNumber = Console.ReadLine();
            }
            //Need to validte license number input 
            Console.WriteLine("Please choose type of fuel you wish to use: ");
            //Need to create FuelType menu
            eFuelType fuelType;
            Enum.TryParse(Console.ReadLine(), out fuelType);
            Console.WriteLine("Please choose the amount you wish to fuel: ");
            float fuelAmount;
            float.TryParse(Console.ReadLine(), out fuelAmount);
            //What happens if fuel amount is invalid
            Garage.FuelCar(licenseNumber , fuelType , fuelAmount);
        }
        public void ChargeVehicle()
        {
            Console.WriteLine("Please enter license Number of the vehicle you wish to charge: ");
            string licenseNumber = Console.ReadLine();
            while (!Garage.VehicleExists(licenseNumber))
            {
                licenseNumber = Console.ReadLine();
            }
            //Need to validate license number input
            Console.WriteLine("Please enter the amount of mkinutes you wish to charge: ");
            float minutesAmount;
            float.TryParse(Console.ReadLine(), out minutesAmount);
            //What happens if minutes amount is invalid
            Garage.ChargeCar(licenseNumber , minutesAmount);
        }

        public void InputIsNotEmpty(string i_Value)
        {
            if(i_Value == String.Empty)
            {
                throw new ArgumentException("didnt enter value");
            }
        }
    }
}
