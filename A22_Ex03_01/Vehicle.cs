using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A22_Ex03_01
{
    public abstract class Vehicle
    {
        private string m_VehicleModel;
        private string m_LicenseNumber;
        private float m_EnergySourceLeft;
        private List<Wheel> m_Wheels; 
        private Engine m_Engine; 
        private InfoOnCar m_InfoOnCar; //need to check with david

        public Vehicle(string i_VehicleModel, string i_LicenseNumber, float i_EnergySourceLeft,  
                        List<Wheel> i_Wheels, Engine i_Engine, InfoOnCar i_InfoOnCar)
        {
            m_VehicleModel = i_VehicleModel;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergySourceLeft = i_EnergySourceLeft;
            m_Wheels = i_Wheels; 
            m_Engine = i_Engine;
            m_InfoOnCar = i_InfoOnCar;
        }

        public string VehicleModel
        {
            get
            { return m_VehicleModel;}
            set
            { m_VehicleModel = value;}
        }
        public string LicenseNumber {
            get
            { return m_LicenseNumber; }
            set
            { m_LicenseNumber = value; }
        }
        public float EnergySourceLeft
        {
            get
            {
                return m_EnergySourceLeft;
            }
            set
            {
                m_EnergySourceLeft = value;
            }
        }
        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
            
        }
        public InfoOnCar InfoOnCar
        {
            get
            {
                return m_InfoOnCar;
            }
        }
        public List<Wheel> Wheels {
            get
            {
                return Wheels; //need to check the set
            }
        }

    }
}
