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
        private const string k_ChooseLicenseMessage = "Choose the license type of the motorcycle:";
        private const string k_EnterEngineVolumeMessage = "Please enter your engine volume a positive number between 0 - 3000: ";

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

            extraInfoMenu.Add(k_ChooseLicenseMessage, tempGarageManager.GeneralMenu(noneLicenseType).ToString());
            extraInfoMenu.Add(k_EnterEngineVolumeMessage, null);

            return extraInfoMenu;
        }

        public sealed override void UpdateUniqueInfo(string i_KeyMessage, string i_UserInput)
        {
            Garage garage = new Garage();
            switch (i_KeyMessage)
            {
                case k_ChooseLicenseMessage:
                    eLicenseType noneLicenseType = eLicenseType.None;
                    garage.EnumInputValidator(i_UserInput, noneLicenseType);
                    m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_UserInput);
                    ShowUniqueInfoMenuForChoice(k_ChooseLicenseMessage);
                    break;
                case k_EnterEngineVolumeMessage:
                    validatingEngineVolumeInput(i_UserInput);
                    m_EngineVolume = int.Parse(i_UserInput);
                    break;
            }
        }

        public override StringBuilder ShowUniqueInfoMenuForChoice(string i_Message)
        {
            StringBuilder menu = new StringBuilder();
            if(i_Message.Equals(k_ChooseLicenseMessage))
            {
                Garage garage = new Garage();
                eLicenseType licenseType = eLicenseType.None;
                menu = garage.GeneralMenu(eLicenseType.None);
            }
            return menu;
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

        public override string DetailsOfVehicle()
        {
            string details = base.DetailsOfVehicle();
            details += String.Format(@"Engine Volume: {0}
License Type: {1}" ,EngineVolume , LicenseType );
            return details;
        }
    }
}
