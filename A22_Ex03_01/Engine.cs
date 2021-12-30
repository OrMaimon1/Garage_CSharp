using System;
using System.Collections.Generic;

namespace A22_Ex03_01
{
    public abstract class Engine
    {
        private float m_MaxEnergySource;
        private float m_EnergySourceLeft;
        public Engine(float i_MaxEnergySource, float i_EnergySourceLeft)
        {
            m_MaxEnergySource = i_MaxEnergySource;
            m_EnergySourceLeft = i_EnergySourceLeft;
        }
        public float MaxEnergySource
        {
            get
            {
                return this.m_MaxEnergySource;
            }
            set
            {
                m_MaxEnergySource = value;
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
