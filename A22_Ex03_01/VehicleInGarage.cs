using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A22_Ex03_01
{
    public class VehicleInGarage
    {
        private string m_OwnerName; //need to check with david
        private string m_PhoneNumber; //need to check with david
        private eVehicleState m_VehicleState; //need to check with david
        private Vehicle m_Vehicle;

        /*public InfoOnCar(string i_Ownername, string i_PhoneNumber , eVehicleState i_VehicleState)
        {
            m_OwnerName = i_Ownername;
            m_PhoneNumber = i_PhoneNumber;
            m_VehicleState = i_VehicleState;
        }*/
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
