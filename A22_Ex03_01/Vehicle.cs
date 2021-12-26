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
        private float m_EnergyPercentage;
        private string m_OwnerName; //need to check with david
        private string m_PhoneNumber; //need to check with david
        private eVehicleState m_VehicleState; //need to check with david
        private List<Wheel> m_Wheels; //need to check with david
        private Engine m_Engine; //need to check with david

        public Vehicle(string i_VehicleModel, string i_LicenseNumber, float i_EnergyPercentage, string i_OwnerName, 
                       string i_PhoneNumber, eVehicleState i_VehicleState, List<Wheel> i_Wheels, Engine i_Engine)
        {
            m_VehicleModel = i_VehicleModel;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyPercentage = i_EnergyPercentage;
            m_OwnerName = i_OwnerName;
            m_PhoneNumber = i_PhoneNumber;
            m_VehicleState = i_VehicleState;
            m_Wheels = new List<Wheel>(); //need to check
            m_Engine = new Engine(); //need to check

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
        public float EnergyPercentage {
            get
            { 
                return m_EnergyPercentage;
            }
            set
            { 
                m_EnergyPercentage = value;
            }
        }
        public string OwnerName {
            get
            { 
                return m_OwnerName;
            }
            set
            { 
                m_OwnerName = value;
            }
        }
        public string PhoneNumber {
            get
            {
                return m_PhoneNumber;
            }
            set
            {
                m_PhoneNumber = value;
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
    }
}
