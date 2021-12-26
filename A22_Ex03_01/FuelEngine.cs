using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A22_Ex03_01
{
    public class FuelEngine : Engine
    {
        private eFuelType m_FuelType;
        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount;

        public void Refueling()
        {

        }

        public eFuelType FuelType 
        { 
            get
            {
                return m_FuelType;
            } 
            set
            {
                m_FuelType = value;
            }
        }

        public float CurrentFuelAmount { 
            get
            {
                return m_CurrentFuelAmount;
            }
            set
            {
                m_CurrentFuelAmount = value;
            }
        }

        public float MaxFuelAmount {
            get
            {
                return m_MaxFuelAmount;
            } 
            set
            {
                MaxFuelAmount = value;
            }
        }
    }
}
