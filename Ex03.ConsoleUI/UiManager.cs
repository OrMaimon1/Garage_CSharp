using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                Console.WriteLine("Enter the license number of the vehicle (7 digits)");
                string licenseNumber = Console.ReadLine();
                Garage.CheckingLicenseInput(licenseNumber);
                if(Garage.VehicleExists(licenseNumber))
                {
                    Garage.AddExistingVehicle(licenseNumber);
                }
                else
                {
                    Console.WriteLine("Please choose vehicle type: ");
                    eVehicleType eVehicleType = eVehicleType.None;
                    Console.Write(Garage.GeneralMenu(eVehicleType));
                    string vehicleType = Console.ReadLine();
                    Vehicle vehicle = VehicleFactory.CreateVehicle(vehicleType, licenseNumber);
                    VehicleInGarage vehicleInGarage = new VehicleInGarage();
                    vehicleInGarage.Vehicle = vehicle;
                    EnteringGeneralInfo(vehicleInGarage);
                    Hashtable UniqueInfoOfVehicle = vehicle.FetchUniqueInfo();
                    foreach(string infoToFill in UniqueInfoOfVehicle.Keys)
                    {
                        Console.WriteLine(infoToFill);
                        Console.WriteLine(vehicle.ShowUniqueInfoMenuForChoice(infoToFill));
                        vehicle.UpdateInfo(infoToFill, Console.ReadLine());
                    }
                    Garage.AddNewVehicle(licenseNumber, vehicleInGarage);
                }
            }
            catch(FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(ValueOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public void EnteringGeneralInfo(VehicleInGarage i_VehicleInGarage)
        {
            float energySourceLeft = (i_VehicleInGarage.Vehicle.Engine.EnergySourceLeft
                                      / i_VehicleInGarage.Vehicle.Engine.MaxEnergySource) / 100;
            Console.WriteLine("Please enter your name: ");
            string fullName = Console.ReadLine();
            InputIsNotEmpty(fullName);
            if((fullName.All(char.IsDigit)))
            {
                throw new ArgumentException("invalid input, dont enter a number in name" + Environment.NewLine);
            }
            Console.WriteLine("Please enter your phone number: ");
            string phoneNumber = Console.ReadLine();
            InputIsNotEmpty(phoneNumber);
            if(!(phoneNumber.All(char.IsDigit)))
            {
                throw new ArgumentException("please enter a number" + Environment.NewLine);
            }
            Console.WriteLine("Please enter the model of the vehicle: ");
            string modelName= Console.ReadLine();
            InputIsNotEmpty(modelName);
            Console.WriteLine("Please enter the manufacture of the wheels: ");
            string manufactureOfTheWheels = Console.ReadLine();
            InputIsNotEmpty(manufactureOfTheWheels);
            i_VehicleInGarage.OwnerName = fullName;
            i_VehicleInGarage.PhoneNumber = phoneNumber;
            i_VehicleInGarage.Vehicle.VehicleModel = modelName;
            i_VehicleInGarage.Vehicle.PercentEnergySourceLeft = energySourceLeft;
            i_VehicleInGarage.Vehicle.InsertWheelManufactureName(manufactureOfTheWheels);
        }
        public void UpdateVehicleState()
        {
            try
            {
                string licenseNumber = AskUserForLicenseNumber();
                Console.WriteLine("Please choose the new state of the vehicle: ");
                eVehicleState vehicleState = eVehicleState.None;
                Console.Write(Garage.GeneralMenu(vehicleState));
                string userChoice = Console.ReadLine();
                Enum.TryParse(userChoice, out vehicleState);
                Garage.UpdateVehicleState(licenseNumber, vehicleState);
                Console.WriteLine("Your vehicle state is updated !"+Environment.NewLine);
            }
            catch(FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(ValueOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public void ViewVehicleLicense()
        {
            try
            {
                eVehicleState vehicleState = eVehicleState.None;
                Console.WriteLine("Please choose the vehicle state of the Licenses you wish to view ");
                Console.Write(Garage.GeneralMenu(vehicleState));
                Enum.TryParse(Console.ReadLine(), out vehicleState);
                List<string> licensesToView = Garage.ShowListOfLicenses(vehicleState);
                Console.WriteLine(format: @"the vehicle licenses in {0} are:",vehicleState);
                foreach(string license in licensesToView)
                {
                    Console.WriteLine(license);
                }
            }
            catch(FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(ValueOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public void InflateWheelsToMax()
        {
            string licenseNumber = AskUserForLicenseNumber();
            if(!Garage.VehicleExists(licenseNumber))
            {
                throw new Exception("Could Not find vehicle");
            }
            Garage.InflateWheelsToMaximumPressure(licenseNumber);
        }

        public void FuelVehicle()
        {
            try
            {
                string licenseNumber = AskUserForLicenseNumber();
                Console.WriteLine("Please choose type of fuel you wish to use: ");
                eFuelType fuelType = eFuelType.None;
                Console.Write(Garage.GeneralMenu(fuelType));
                Enum.TryParse(Console.ReadLine(), out fuelType);
                Console.WriteLine("Please choose the amount you wish to fuel: ");
                float fuelAmount;
                float.TryParse(Console.ReadLine(), out fuelAmount);
                Garage.FuelCar(licenseNumber, fuelType, fuelAmount);
            }
            catch(FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(ValueOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public void ChargeVehicle()
        {
            try
            {
                string licenseNumber = AskUserForLicenseNumber();
                Console.WriteLine("Please enter the amount of minutes you wish to charge: ");
                float minutesAmount;
                float.TryParse(Console.ReadLine(), out minutesAmount);
                Garage.ChargeCar(licenseNumber, minutesAmount);
            }
            catch(FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(ValueOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public void GetVehicleDetails()
        {
            string licenseNumber = AskUserForLicenseNumber();
            VehicleInGarage vehicle = Garage.GetVehicle(licenseNumber);
            string detailsOfVehicle = vehicle.Vehicle.DetailsOfVehicle();
            Console.WriteLine(detailsOfVehicle);
        }
        public void InputIsNotEmpty(string i_Value)
        {
            if(i_Value == String.Empty)
            {
                throw new ArgumentException("didn't enter value");
            }
        }
        public string AskUserForLicenseNumber()
        {
            Console.WriteLine("Please choose the license number of the vehicle you wish to work on");
            string licenseNumber = Console.ReadLine();
            while (!Garage.VehicleExists(licenseNumber))
            {
                Console.WriteLine("Could Not find license number , try again");
                licenseNumber = Console.ReadLine();
            }
            return licenseNumber;
        }
    }
}
