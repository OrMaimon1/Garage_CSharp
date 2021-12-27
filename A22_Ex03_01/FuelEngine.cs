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

        public FuelEngine(float i_MaxEnergySource, float i_EnergySourceLeft, eFuelType i_FuelType)
            :base(i_MaxEnergySource, i_EnergySourceLeft)
        {
            m_FuelType = i_FuelType;
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


        public void ReFuel(float i_AmountToFuel, eFuelType i_FuelType)
        {
            if(FuelType == i_FuelType)
            {
                if(EnergySourceLeft + i_AmountToFuel <= MaxEnergySource && i_AmountToFuel > 0)
                {
                    EnergySourceLeft += i_AmountToFuel;
                }
                else
                {
                    throw new ValueOutOfRangeException(EnergySourceLeft, MaxEnergySource); //need to check
                }
            }
        }
    }
}
