﻿using System;
using System.Collections.Generic;
using System.Text;

namespace A22_Ex03_01
{
    public class Garage
    {
        private Dictionary<string, VehicleInGarage> m_AllAllVehiclesInGarage;
        private VehicleInGarage m_InfoOnCar;
        public Garage()
        {
            m_AllAllVehiclesInGarage = new Dictionary<string, VehicleInGarage>();
        }
        public Dictionary<string, VehicleInGarage> AllVehiclesInGarage
        {
            get
            {
                return m_AllAllVehiclesInGarage;
            }
        }
        public VehicleInGarage InfoOnCar
        {
            get
            {
                return m_InfoOnCar;
            }
        }
        public void AddExistingVehicle(string i_license)
        {
            VehicleInGarage vehicleInGarage;
            AllVehiclesInGarage.TryGetValue(i_license, out vehicleInGarage);
            vehicleInGarage.VehicleState = eVehicleState.Fixing;
        }
        public void AddNewVehicle(string i_license, VehicleInGarage i_Vehicle)
        {
            AllVehiclesInGarage.Add(i_license, i_Vehicle);
        }
        public List<string> ShowListOfLicenses(eVehicleState i_VehicleState)
        {
            List<string> listOfLicenses = new List<string>();
            if(i_VehicleState == eVehicleState.None)
            {
                foreach(KeyValuePair<string, VehicleInGarage> vehicleInGarage in AllVehiclesInGarage)
                {
                    listOfLicenses.Add(vehicleInGarage.Value.Vehicle.LicenseNumber);
                }
            }
            else
            {
                foreach (VehicleInGarage vehicleInGarage in AllVehiclesInGarage.Values)
                {
                    if(vehicleInGarage.VehicleState == i_VehicleState)
                    {
                        listOfLicenses.Add(vehicleInGarage.Vehicle.LicenseNumber);
                    }
                }
            }
            return listOfLicenses;
        }
        public void UpdateVehicleState(string i_License, eVehicleState i_NewState)
        {
            VehicleInGarage vehicle;
            AllVehiclesInGarage.TryGetValue(i_License, out vehicle);
            vehicle.VehicleState = i_NewState;
        }
        public void InflateWheelsToMaximumPressure(string i_License)
        {
            VehicleInGarage vehicleInGarage;
            float currentPressure;
            float maxPressure;
            AllVehiclesInGarage.TryGetValue(i_License, out vehicleInGarage);
            foreach (Wheel wheel in vehicleInGarage.Vehicle.Wheels)
            {
                currentPressure = wheel.CurrentAirPressure;
                maxPressure = wheel.MaxAirPressure;
                wheel.Inflate(maxPressure - currentPressure);
            }
        }
        public void FuelCar(string i_License, eFuelType i_FuelType, float i_AmountToFuel)         {
            VehicleInGarage vehicleInGarage;
            AllVehiclesInGarage.TryGetValue(i_License, out vehicleInGarage);
            if(vehicleInGarage.Vehicle.Engine != (vehicleInGarage.Vehicle.Engine as FuelEngine))
            {
                throw new ArgumentException("your vehicle is electric try to charge");
            }
            (vehicleInGarage.Vehicle.Engine as FuelEngine).ReFuel(i_AmountToFuel, i_FuelType);
        }
        public void ChargeCar(string i_License, float i_MinutesToCharge) 
        {
            VehicleInGarage vehicleInGarage;
            AllVehiclesInGarage.TryGetValue(i_License, out vehicleInGarage);
            if (vehicleInGarage.Vehicle.Engine != (vehicleInGarage.Vehicle.Engine as ElectricEngine))
            {
                throw new ArgumentException("your vehicle is electric try to charge");
            }
            (vehicleInGarage.Vehicle.Engine as ElectricEngine).ReCharge(i_MinutesToCharge);
        }
        public VehicleInGarage GetVehicle(string i_License)
        {
            VehicleInGarage vehicleInGarage;
            AllVehiclesInGarage.TryGetValue(i_License, out vehicleInGarage);
            return vehicleInGarage;
        }
        public bool VehicleExists(string i_LicenseNumber)
        {
            return AllVehiclesInGarage.ContainsKey(i_LicenseNumber);
        }
        public StringBuilder GeneralMenu(Enum i_TypeOfEnum) 
        {
            int index = 0;
            StringBuilder tempStringBuilder = new StringBuilder();
            Type typeOfEnum = i_TypeOfEnum.GetType();
            tempStringBuilder.AppendLine();
            foreach (string state in Enum.GetNames(typeOfEnum))
            {
                if (state != "None")
                {
                    tempStringBuilder.Append(index + ") ");
                    tempStringBuilder.Append(state);
                    tempStringBuilder.AppendLine();
                }
                index++;
            }
            return tempStringBuilder;
        }
        public void CheckingLicenseInput(string i_UsersLicenseNumber)
        {
            int numberForParse;
            if (!int.TryParse(i_UsersLicenseNumber, out numberForParse))
            {
                throw new FormatException("Wrong number please enter numbers between 0-7 digits");
            }
            if (numberForParse < 0 || numberForParse > 9999999)
            {
                throw new ValueOutOfRangeException(9999999, 0);
            }
        }
        public void EnumInputValidator(string i_userInput, Enum i_Enum)
        {
            int userInput;
            int.TryParse(i_userInput, out userInput);
            int statesCount = (int)(Enum.GetNames(i_Enum.GetType()).Length - 1);
            if(userInput < 1 || userInput > statesCount)
            {
                throw new ValueOutOfRangeException(statesCount, 1);
            }
        }
    }
}
