using System;

namespace A22_Ex03_01
{
    public class VehicleInGarage
    {
        private string m_OwnerName; 
        private string m_PhoneNumber; 
        private eVehicleState m_VehicleState = eVehicleState.Fixing; 
        private Vehicle m_Vehicle;
        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
            set
            {
                m_OwnerName = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }
            set
            {
                m_PhoneNumber = value;
            }
        }
        public eVehicleState VehicleState
        {
            get
            {
                return m_VehicleState;

            }
            set
            {
                m_VehicleState = value;
            }
        }
        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }
    }
}
