using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A22_Ex03_01
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel()
        {

        }
        public void inflate(int i_)
        {
            
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            } set
            {
                m_ManufacturerName =value;
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
