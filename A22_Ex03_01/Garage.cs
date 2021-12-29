using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace A22_Ex03_01
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_VehiclesInGarage;
        private InfoOnCar m_infoOnCar;
        public Garage()
        {
            m_VehiclesInGarage = new Dictionary<string, Vehicle>();
        }

        public Dictionary<string, Vehicle> VehiclesInGarage
        {
            get
            {
                return m_VehiclesInGarage;
            }
        }

        public void AddExistingVehicle(string i_license)
        {
            Vehicle vehicle;
            VehiclesInGarage.TryGetValue(i_license, out vehicle);
            vehicle.InfoOnCar.VehicleState = eVehicleState.Fixing;
        }

        public void AddNewVehicle(string i_license, Vehicle i_Vehicle)
        {
            VehiclesInGarage.Add(i_license, i_Vehicle);
        }

        public List<string> ShowListOfLicenses()
        {
            List<string> listOfLicenses = new List<string>();
            foreach (KeyValuePair<string, Vehicle> vehicle in VehiclesInGarage)
            {
                listOfLicenses.Add(vehicle.Value.LicenseNumber);
            }

            return listOfLicenses;
        }

        public void ChangeVehicleState(string i_License, eVehicleState i_NewState)
        {
            Vehicle vehicle;
            VehiclesInGarage.TryGetValue(i_License, out vehicle);
            vehicle.InfoOnCar.VehicleState = i_NewState;
        }

        public void InflateWheelsToMaximumPressure(string i_License)//in vehical need to check
        {
            Vehicle vehicle;
            float currentPressure;
            float maxPressure;
            VehiclesInGarage.TryGetValue(i_License, out vehicle);
            foreach (Wheel wheel in vehicle.Wheels)
            {
                currentPressure = wheel.CurrentAirPressure;
                maxPressure = wheel.MaxAirPressure;
                wheel.Inflate(maxPressure - currentPressure);
            }
        }

        public void FuelCar(string i_License, eFuelType i_FuelType, float i_AmountToFuel)
        {
            Vehicle vehicle;
            VehiclesInGarage.TryGetValue(i_License, out vehicle);
            (vehicle.Engine as FuelEngine).ReFuel(i_AmountToFuel, i_FuelType);
        }

        public void ChargeCar(string i_License, float i_MinutesToCharge)
        {
            Vehicle vehicle;
            VehiclesInGarage.TryGetValue(i_License, out vehicle);
            (vehicle.Engine as ElectricEngine).ReCharge(i_MinutesToCharge);
        }

        public Vehicle GetVehicle(string i_License)
        {
            Vehicle vehicle;
            VehiclesInGarage.TryGetValue(i_License, out vehicle);
            return vehicle;
        }

        public bool VehicleExists(string i_LicenseNumber)
        {
            return VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public StringBuilder GeneralMenu(Enum i_TypeOfEnum) //added
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

        public void checkingLicenseInput(string i_UsersLicenseNumber)
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
    }
}
