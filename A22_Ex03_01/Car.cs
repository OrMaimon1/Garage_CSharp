using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace A22_Ex03_01
{
    public class Car : Vehicle
    {
        private eColor m_Color;
        private int m_NumberOfDoors;

        public Car(
            string i_VehicleModel, string i_LicenseNumber, float i_EnergyPercentage, string i_OwnerName, string i_PhoneNumber, 
            eVehicleState i_VehicleState, List<Wheel> i_Wheels, Engine i_Engine, eColor i_Color, int i_NumberOfDoors)
            : base(i_VehicleModel, i_LicenseNumber, i_EnergyPercentage, i_OwnerName, i_PhoneNumber, i_VehicleState, i_Wheels, i_Engine)
        {
            m_Color = i_Color;
            m_NumberOfDoors = i_NumberOfDoors; //need to check
        }

        public eColor Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }

        public int NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;

            }
            set
            {
                if(value >= 2 && value <= 5) //need to check
                {
                    m_NumberOfDoors = value;
                }
                else
                {
                    //ArgumentException
                }
                
            }
        }
    }
}
