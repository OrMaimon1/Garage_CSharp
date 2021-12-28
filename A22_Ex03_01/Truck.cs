using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A22_Ex03_01
{
    public class Truck : Vehicle
    {
        private bool m_HasCargo;
        private float m_CargoCapacity;

        public Truck(string i_VehicleModel, string i_LicenseNumber, float i_EnergySourceLeft,
                     List<Wheel> i_Wheels, Engine i_Engine, InfoOnCar i_InfoOnCar)
            : base(i_VehicleModel, i_LicenseNumber, i_EnergySourceLeft, i_Wheels, i_Engine , i_InfoOnCar)
        {
            
        }
        public bool HasCargo
        {
            get
            {
                return m_HasCargo;
            }
            set
            {
                m_HasCargo = value;
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
