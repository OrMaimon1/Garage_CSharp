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
        private readonly List<Wheel> r_Wheels = new List<Wheel>(); 
        private Engine m_Engine; 

        public Vehicle(string i_LicenseNumber, int i_NumberOfWheels)
        {
            m_LicenseNumber = i_LicenseNumber;
            r_Wheels = new List<Wheel>(i_NumberOfWheels);
        }

        public abstract Hashtable FetchUniqueInfo();
        public abstract void UpdateUniqueInfo(string i_KeyMessage, string i_UserInput);

        public abstract StringBuilder ShowUniqueInfoMenuForChoice(string i_message);

        public void CreateTheWheels(float i_MaxAirPressureForWheels, int i_NumberOfWheels) // need to check
        {
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_MaxAirPressureForWheels));
            }
        }
        public void InsertWheelManufactureName(string i_ManufactureOfTheWheels)
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.ManufacturerName = i_ManufactureOfTheWheels;
            }
        }

        public virtual string DetailsOfVehicle()
        {
            string details = String.Format(@"Vehicle Type: {9}
License number: {0}
Model Name: {1}
Energy Source Precentage Left: {2}
Energy Source Left: {3}
Max Energy Source Capacity: {4}
Number Of Wheels: {5}
Wheels Manufacturer Name: {6}
Current Wheel Air Pressure: {7}
Max Wheel Air Pressure: {8}" ,
               LicenseNumber , VehicleModel , PercentEnergySourceLeft , Engine.EnergySourceLeft ,
               Engine.MaxEnergySource , Wheels.Count , Wheels[0].ManufacturerName , Wheels[0].CurrentAirPressure , Wheels[0].MaxAirPressure);
            return details;
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
