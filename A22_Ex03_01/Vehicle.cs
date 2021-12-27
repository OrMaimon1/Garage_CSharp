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
        private readonly List<Wheel> m_Wheels; 
        private Engine m_Engine; 
        private Customer m_Customer; //need to check with david

        public Vehicle(string i_VehicleModel, string i_LicenseNumber, float i_EnergySourceLeft,  
                        List<Wheel> i_Wheels, Engine i_Engine)
        {
            m_VehicleModel = i_VehicleModel;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergySourceLeft = i_EnergySourceLeft;
            m_Wheels = new List<Wheel>(); 
            m_Engine = i_Engine;
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
        public List<Wheel> Wheels {
            get
            {
                return Wheels; //need to check the set
            }
        }

        //public void InflateWheels(int i_AirAmountToAdd)
        //{
        //    foreach (Wheel wheel in Wheels)
        //    {
        //        wheel.inflate(i_AirAmountToAdd);
        //    }
        //}
    }
}
