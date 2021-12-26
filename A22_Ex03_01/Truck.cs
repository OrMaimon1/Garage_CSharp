using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A22_Ex03_01
{
    public class Truck : Vehicle
    {
        private bool m_IsThereContent;
        private float m_CargoCapacity;

        public Truck(string i_VehicleModel, string i_LicenseNumber, float i_EnergyPercentage, string i_OwnerName, string i_PhoneNumber,
                     eVehicleState i_VehicleState, List<Wheel> i_Wheels, Engine i_Engine, bool i_IsThereContent, float i_CargoCapacity) 
            : base(i_VehicleModel, i_LicenseNumber, i_EnergyPercentage, i_OwnerName, i_PhoneNumber, i_VehicleState, i_Wheels, i_Engine)
        {
            m_IsThereContent = i_IsThereContent;
            m_CargoCapacity = i_CargoCapacity;
        }

        public bool IsThereContent
        {
            get
            {
                return m_IsThereContent;

            }
            set
            {
                m_IsThereContent = value;
            }
        }

        public float CargoCapacity
        {
            get
            {
                return m_CargoCapacity;

            }
            set
            {
                m_CargoCapacity = value;
            }
        }
    }
}
