using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace A22_Ex03_01
{
    public class Motorcycle : Vehicle
    {

        private int m_EngineVolume;
        private eLicenseType m_LicenseType;

        public Motorcycle(string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPressureForWheels,Engine i_Engine)
            : base( i_LicenseNumber,i_NumberOfWheels)
        {
            CreateTheWheels(i_MaxAirPressureForWheels, i_NumberOfWheels);
            Engine = i_Engine;
            //Engine = new FuelEngine(i_MaxTankCapacity, 0, i_fuelType);
        }

        public sealed override Hashtable FetchUniqueInfo()
        {
            Garage tempGarageManager = new Garage();
            Hashtable extraInfoMenu = new Hashtable();
            eLicenseType noneLicenseType = eLicenseType.None;

            extraInfoMenu.Add("Choose the license type of the motorcycle:", tempGarageManager.GeneralMenu(noneLicenseType).ToString());
            extraInfoMenu.Add("Please enter your engine volume a positive number between 0 - 3000: ", null);

            return extraInfoMenu;
        }

        public sealed override void UpdateUniqueInfo(string i_KeyMessage, string i_UserInput)
        {
            Garage tempGarageManager = new Garage();
            switch (i_KeyMessage)
            {
                case k_MotorcycleLicenseTypeMessage:
                    eLicenseType noneLicenseType = eLicenseType.None;
                    tempGarageManager.ValidateUsersInputBasedOnTheRangeOfThisEnum(i_UserInput, noneLicenseType);
                    m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_UserInput);
                    break;
                case k_MotorcycleEngineVolumeMessage:
                    validatingEngineVolumeInput(i_UserInput);
                    m_EngineVolume = int.Parse(i_UserInput);
                    break;
            }
        }

        private static void validatingEngineVolumeInput(string i_UserInput)
        {
            int numberForParse;

            if (!int.TryParse(i_UserInput, out numberForParse))
            {
                throw new FormatException("Wrong input");
            }

            if (numberForParse < 0)
            {
                throw new ValueOutOfRangeException(3000, 0);
            }
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
