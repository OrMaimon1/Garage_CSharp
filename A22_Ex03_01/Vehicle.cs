using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace A22_Ex03_01
{
    public abstract class Vehicle
    {
        private string m_VehicleModel;
        private string m_LicenseNumber;
        private float m_PercentEnergySourceLeft;
        private readonly List<Wheel> r_Wheels; 
        private Engine m_Engine; 

        public Vehicle(string i_LicenseNumber, int i_NumberOfWheels)
        {
            m_LicenseNumber = i_LicenseNumber;
            r_Wheels = new List<Wheel>(i_NumberOfWheels);
        }

        public abstract Hashtable FetchUniqueInfo();
        public abstract void UpdateUniqueInfo(string i_KeyMessage, string i_UserInput);

        public List<Wheel> CreateTheWheels(float i_MaxAirPressureForWheels, int i_NumberOfWheels) // need to check
        {
            List<Wheel> wheels = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                wheels.Add(new Wheel(i_MaxAirPressureForWheels));
            }

            return wheels;
        }

        public void InsertManufactureName(string i_ManufactureOfTheWheels)
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.ManufacturerName = i_ManufactureOfTheWheels;
            }
        }
        public void InflateAirToMax()
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
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
        public float PercentEnergySourceLeft
        {
            get
            {
                return m_PercentEnergySourceLeft;
            }
            set
            {
                m_PercentEnergySourceLeft = value;
            }
        }
        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
            set
            {
                m_Engine = value;
            }
        }
        public List<Wheel> Wheels {
            get
            {
                return r_Wheels; //need to check the set
            }
            set
            {

            }
        }

    }
}
