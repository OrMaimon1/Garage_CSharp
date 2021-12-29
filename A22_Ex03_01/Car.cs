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

        public Car(string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPressureForWheels,Engine i_Engine)
            : base(i_LicenseNumber, i_NumberOfWheels)
        {
            CreateTheWheels(i_MaxAirPressureForWheels, i_NumberOfWheels);
            Engine = i_Engine;
            //Engine = new FuelEngine(i_MaxTankCapacity, 0, i_fuelType);
        }

        public sealed override Hashtable FetchUniqueInfo()
        {
            Garage tempGarageManager = new Garage();
            Hashtable extraInfoMenu = new Hashtable();
            eColor noneCarColor = eColor.None;
            eNumberOfDoors noneNumberOfDoors = eNumberOfDoors.None;

            extraInfoMenu.Add(k_CarColorMessage, tempGarageManager.GeneralMenu(noneCarColor).ToString());
            extraInfoMenu.Add(k_NumberOfDoorsMessage, tempGarageManager.GeneralMenu(noneNumberOfDoors).ToString());

            return extraInfoMenu;
        }

        public sealed override Hashtable FetchUniqueInfo()
        {
            Garage tempGarageManager = new Garage();
            Hashtable extraInfoMenu = new Hashtable();
            eColor noneCarColor = eColor.None;
            eNumberOfDoors noneNumberOfDoors = eNumberOfDoors.None;

            extraInfoMenu.Add(k_CarColorMessage, tempGarageManager.GeneralMenu(noneCarColor).ToString());
            extraInfoMenu.Add(k_NumberOfDoorsMessage, tempGarageManager.GeneralMenu(noneNumberOfDoors).ToString());

            return extraInfoMenu;
        }

        public sealed override void UpdateUniqueInfo(string i_KeyMessage, string i_UserInput)
        {
            Garage tempGarageManager = new Garage();

            switch (i_KeyMessage)
            {
                case k_CarColorMessage:
                    eColor noneCarColor = eColor.None;
                    tempGarageManager.ValidateUsersInputBasedOnTheRangeOfThisEnum(i_UserInput, noneCarColor);
                    m_Color = (eColor)Enum.Parse(typeof(eColor), i_UserInput);
                    break;
                case k_NumberOfDoorsMessage:
                    eNumberOfDoors noneNumberOfDoors = eNumberOfDoors.None;
                    tempGarageManager.ValidateUsersInputBasedOnTheRangeOfThisEnum(i_UserInput, noneNumberOfDoors);
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
    }
}
