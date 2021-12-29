using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq.Expressions;
using System.Text;

namespace A22_Ex03_01
{
    public class Car : Vehicle
    {
        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;
        private const string k_ChooseCarColorMessage = "Please choose the color of the car";
        private const string k_ChooseNumberOfDoorsMessage = "Please choose number Of doors";
        public Car(string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPressureForWheels,Engine i_Engine)
            : base(i_LicenseNumber, i_NumberOfWheels)
        {
            CreateTheWheels(i_MaxAirPressureForWheels, i_NumberOfWheels);
            Engine = i_Engine;
            //Engine = new FuelEngine(i_MaxTankCapacity, 0, i_fuelType);
        }

        public sealed override Hashtable FetchUniqueInfo()
        {
            Garage GarageManager = new Garage();
            Hashtable extraInfoMenu = new Hashtable();
            eColor noColor = eColor.None;
            eNumberOfDoors noDoors = eNumberOfDoors.None;

            extraInfoMenu.Add(k_ChooseCarColorMessage, GarageManager.GeneralMenu(noColor).ToString());
            extraInfoMenu.Add(k_ChooseNumberOfDoorsMessage, GarageManager.GeneralMenu(noDoors).ToString());

            return extraInfoMenu;
        }

        public sealed override void UpdateUniqueInfo(string i_KeyMessage, string i_UserInput)
        {
            Garage garage = new Garage();

            switch (i_KeyMessage)
            {
                case k_ChooseCarColorMessage:
                    eColor noneCarColor = eColor.None;
                    garage.EnumInputValidator(i_UserInput, noneCarColor);
                    m_Color = (eColor)Enum.Parse(typeof(eColor), i_UserInput);
                    break;
                case k_ChooseNumberOfDoorsMessage:
                    eNumberOfDoors noneNumberOfDoors = eNumberOfDoors.None;
                    garage.EnumInputValidator(i_UserInput, noneNumberOfDoors);
                    m_NumberOfDoors = (eNumberOfDoors)Enum.Parse(typeof(eNumberOfDoors), i_UserInput);
                    break;
            }
        }

        public eColor Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;

            }
            set
            {
                m_NumberOfDoors = value;

            }

        }

        public override string DetailsOfVehicle()
        {
            string details = base.DetailsOfVehicle();
            details += String.Format(@"Car Color: {0}
Doors Number: {1}" , Color , NumberOfDoors);
            return details;
        }
    }

}
