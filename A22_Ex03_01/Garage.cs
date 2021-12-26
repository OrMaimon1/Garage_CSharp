using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A22_Ex03_01
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_VehiclesInGarage;

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

        public void AddVehicle(string i_license, Vehicle i_Vehicle)
        {
            if(VehiclesInGarage.ContainsKey(i_license))
            {
                VehiclesInGarage.TryGetValue(i_license, out i_Vehicle);
                i_Vehicle.VehicleState = eVehicleState.Fixing;
                //Turn the state of vehicle to "In Repair"
            }
            else
            {
                VehiclesInGarage.Add(i_license , i_Vehicle);
            }
        }

        public List<string> ShowListOfLicenses()
        {
            List<string> listOfLicenses = new List<string>();
            foreach(KeyValuePair<string , Vehicle> vehicle in VehiclesInGarage)
            {
                listOfLicenses.Add(vehicle.Value.LicenseNumber);
            }

            return listOfLicenses;
        }
    }
}
