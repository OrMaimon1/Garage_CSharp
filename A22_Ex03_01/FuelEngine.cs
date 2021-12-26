using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace A22_Ex03_01
{
    public class FuelEngine : Engine
    {
        private eFuelType m_FuelType;
        //private float m_CurrentFuelAmount;
        //private float m_MaxFuelAmount;

        public FuelEngine(eFuelType i_FuelType)
        {
            this.m_FuelType = i_FuelType;
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

        /*public float CurrentFuelAmount { 
            get
            {
                return m_CurrentFuelAmount;
            }
            set
            {
                m_CurrentFuelAmount = value;
            }
        }*/

        /*public float MaxFuelAmount {
            get
            {
                return m_MaxFuelAmount;
            } 
            set
            {
                MaxFuelAmount = value;
            }
        }*/

        public void ReFuel(float i_AmountToFuel, eFuelType i_FuelType)
        {
            if(FuelType == i_FuelType)
            {
                if(EnergySourceLeft + i_AmountToFuel <= MaxEnergySource)
                {
                    EnergySourceLeft += i_AmountToFuel;
                }
            }
        }
    }
}
