﻿using System;

namespace A22_Ex03_01
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        public Wheel(float i_MaxAirPressure)
        {
            m_ManufacturerName = string.Empty;
            m_CurrentAirPressure = 0;
            m_MaxAirPressure = i_MaxAirPressure;
        }
        public void Inflate(float i_AddAirPressure)
        {
            if(CurrentAirPressure + i_AddAirPressure <= MaxAirPressure && i_AddAirPressure > 0)
            {
                CurrentAirPressure += i_AddAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(CurrentAirPressure, MaxAirPressure); //need to check 
            }
        }
        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            } 
            set
            {
                m_ManufacturerName = value;
            }
        }
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;

            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }
        public float MaxAirPressure { 
            get
            {
                return m_MaxAirPressure;
            } 
            set
            {
                m_MaxAirPressure = value;
            }
        }
    }
}
