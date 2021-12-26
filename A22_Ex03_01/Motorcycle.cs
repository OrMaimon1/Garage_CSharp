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

        public Motorcycle(string i_VehicleModel, string i_LicenseNumber, float i_EnergyPercentage, string i_OwnerName, string i_PhoneNumber,
                          eVehicleState i_VehicleState, List<Wheel> i_Wheels, Engine i_Engine, int i_EngineVolume, eLicenseType i_LicenseType)
            : base(i_VehicleModel, i_LicenseNumber, i_EnergyPercentage, i_OwnerName, i_PhoneNumber, i_VehicleState, i_Wheels, i_Engine)
        {
            //Wheels = new List<Wheel>(2);
            Wheels.Add(null);// need to check
            // Wheels.Add(,) //need to check how to add number of wheels
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
