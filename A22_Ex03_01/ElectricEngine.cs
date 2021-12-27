using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A22_Ex03_01
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxEnergySource, float i_EnergySourceLeft)
            : base(i_MaxEnergySource, i_EnergySourceLeft)
        {
            
        }

        public void ReCharge(float i_AmountToAdd)
        {
            if(EnergySourceLeft + i_AmountToAdd <= MaxEnergySource && i_AmountToAdd > 0)
            {
                EnergySourceLeft += i_AmountToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(EnergySourceLeft , MaxEnergySource); //need to check
            }
            
        }

    }
}
