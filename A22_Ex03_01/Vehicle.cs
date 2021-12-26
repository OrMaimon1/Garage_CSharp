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
        private eVehicleState m_VehicleState; //need to check with david
        private List<Wheel> m_Wheels; //need to check with david
        private Engine m_Engine; //need to check with david

        public Vehicle(string i_VehicleModel, string i_LicenseNumber, float i_EnergySourceLeft, string i_OwnerName, 
                       string i_PhoneNumber, eVehicleState i_VehicleState, List<Wheel> i_Wheels, Engine i_Engine)
        {
            m_VehicleModel = i_VehicleModel;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergySourceLeft = i_EnergySourceLeft;
            m_VehicleState = i_VehicleState;
            m_Wheels = new List<Wheel>(); //need to check
            //m_Engine = new Engine(); //need to check
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
                return Engine.EnergySourceLeft;
            }
            set
            {
                m_EnergySourceLeft = value;
            }
        }
        public eVehicleState VehicleState {
            get
            {
                return VehicleState;
            }
            set
            {
                m_VehicleState = value;
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

        public void InflateWheels(int i_AirAmountToAdd)
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.inflate(i_AirAmountToAdd);
            }
        }
    }
}
