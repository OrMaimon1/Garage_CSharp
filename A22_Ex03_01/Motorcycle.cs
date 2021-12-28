using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A22_Ex03_01
{
    public class Motorcycle : Vehicle
    {

        private int m_EngineVolume;
        private eLicenseType m_LicenseType;

        public Motorcycle(string i_VehicleModel, string i_LicenseNumber, float i_EnergySourceLeft,
                          List<Wheel> i_Wheels, Engine i_Engine, InfoOnCar i_InfoOnCar)
            : base(i_VehicleModel, i_LicenseNumber, i_EnergySourceLeft, i_Wheels, i_Engine, i_InfoOnCar)
        {
            
        }

        public int EngineVolume {
            get
            { 
                return m_EngineVolume;
            }
            set
            {
                m_EngineVolume = value;
            }
        }

        public eLicenseType LicenseType {
            get
            { 
                return m_LicenseType;
            }
            set
            { 
                m_LicenseType = value;
            }
        }  

    }
}
