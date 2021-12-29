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
                    vehicle.UpdateUniqueInfo(infoToFill , Console.ReadLine());
                }
                Garage.AddNewVehicle(licenseNumber , vehicleInGarage);
            }
        }
        public void EnteringGeneralInfo(VehicleInGarage i_VehicleInGarage)
        {
            string fullName = string.Empty;
            string phoneNumber = string.Empty;
            string modelName = string.Empty;
            float energySourceLeft = (i_VehicleInGarage.Vehicle.Engine.EnergySourceLeft
                                      / i_VehicleInGarage.Vehicle.Engine.MaxEnergySource) / 100;
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
            manufactureOfTheWheels = Console.ReadLine();
            InputIsNotEmpty(manufactureOfTheWheels);
            i_VehicleInGarage.OwnerName = fullName;
            i_VehicleInGarage.PhoneNumber = phoneNumber;
            i_VehicleInGarage.Vehicle.VehicleModel = modelName;
            i_VehicleInGarage.Vehicle.PercentEnergySourceLeft = energySourceLeft;
            i_VehicleInGarage.Vehicle.InsertWheelManufactureName(manufactureOfTheWheels);
            //m_Garage.AddGeneralInfo(i_VehicleInGarage, fullName, phoneNumber, modelName);
            //i_VehicleInGarage.CurrentVehicle.InsertWheelManufactureName(manufactureOfTheWheels);
        }

        
        public void UpdateVehicleState()
        {
            string licenseNumber = AskUserForLicenseNumber();
            Console.WriteLine("Please choose the new state of the vehicle: ");
            eVehicleState vehicleState = eVehicleState.None;
            Garage.GeneralMenu(vehicleState);
            //Need to creaate a menu for vehicle states
            string userChoice = Console.ReadLine();
            Enum.TryParse(userChoice, out vehicleState);
            Garage.UpdateVehicleState(licenseNumber , vehicleState);
        }

        public void ViewVehicleLicense()
        {
            eVehicleState vehicleState = eVehicleState.None;
            Console.WriteLine("Please choose the vehicle state of the Licenses you wish to view ");
            //Need to create a menu for Vehicle state
            Console.Write(Garage.GeneralMenu(vehicleState));
            Enum.TryParse(Console.ReadLine(), out vehicleState);
            List<string> licensesToView = Garage.ShowListOfLicenses(vehicleState);
            foreach(string license in licensesToView)
            {
                Console.WriteLine(license);
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
            string licenseNumber = AskUserForLicenseNumber();
            //Need to validte license number input 
            Console.WriteLine("Please choose type of fuel you wish to use: ");
            eFuelType fuelType = eFuelType.None;
            Garage.GeneralMenu(fuelType);
            Enum.TryParse(Console.ReadLine(), out fuelType);
            Console.WriteLine("Please choose the amount you wish to fuel: ");
            float fuelAmount;
            float.TryParse(Console.ReadLine(), out fuelAmount);
            //What happens if fuel amount is invalid
            Garage.FuelCar(licenseNumber , fuelType , fuelAmount);
        }
        public void ChargeVehicle()
        {
            string licenseNumber = AskUserForLicenseNumber();
            //Need to validate license number input
            Console.WriteLine("Please enter the amount of mkinutes you wish to charge: ");
            float minutesAmount;
            float.TryParse(Console.ReadLine(), out minutesAmount);
            //What happens if minutes amount is invalid
            Garage.ChargeCar(licenseNumber , minutesAmount);
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
                throw new ArgumentException("didnt enter value");
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
            //Garage.CheckingLicenseInput(licenseNumber);
            return licenseNumber;
        }
    }
}
