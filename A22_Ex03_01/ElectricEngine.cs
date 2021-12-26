using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A22_Ex03_01
{
    public class ElectricEngine : Engine
    {
        //private float m_TimeRemainOnBattery;
        //private float m_MaxTimeOnBattery;

        public void Recharge(float i_AmountToAdd)
        {
            if(EnergySourceLeft + i_AmountToAdd <= MaxEnergySource)
            {
                EnergySourceLeft += i_AmountToAdd;
            }
        }

    }
}
