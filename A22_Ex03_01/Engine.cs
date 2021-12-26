using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A22_Ex03_01
{
    public abstract class Engine
    {
        private float m_MaxEnergySource;
        private float m_EnergySourceLeft;
        //private FuelEngine m_FuelEngine;
        //private ElectricEngine m_ElectricEngine;

        public Engine()
        {

        }

        //public virtual void ReSupplyEnergySource(float i_AmountToFuel ){}
        public float MaxEnergySource
        {
            get
            {
                return this.m_MaxEnergySource;
            }
        }

        public float EnergySourceLeft
        {
            get
            {
                return this.m_EnergySourceLeft;
            }
            set
            {
                this.m_EnergySourceLeft = value;
            }
        }


    }
}
