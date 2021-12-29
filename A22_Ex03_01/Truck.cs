using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace A22_Ex03_01
{
    public class Truck : Vehicle
    {
        private bool m_HasCargo;
        private float m_CargoCapacity;

        public Truck(string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPressureForWheels, Engine i_Engine)
            : base(i_LicenseNumber, i_NumberOfWheels)
        {
            CreateTheWheels(i_MaxAirPressureForWheels, i_NumberOfWheels);
            Engine = i_Engine;
        }



        public override Hashtable FetchUniqueInfo()
        {
            Hashtable extraInfoMenu = new Hashtable();

            extraInfoMenu.Add(k_DangerMaterialsMessage, null);
            extraInfoMenu.Add(k_MaxWightLoadMessage, null);

            return extraInfoMenu;
        }

        public override void UpdateUniqueInfo(string i_KeyMessage, string i_UserInput)
        {
            switch (i_KeyMessage)
            {
                case k_DangerMaterialsMessage:
                    HasCargoValidation(i_UserInput); //תכולה בקירור
                    if (i_UserInput == "Yes")
                    {
                        m_HasCargo = true;
                    }

                    break;

                case k_MaxWightLoadMessage:
                    validatingMaxCarryWeight(i_UserInput);
                    m_CargoCapacity = float.Parse(i_UserInput);
                    break;
            }
        }

        private static void HasCargoValidation(string i_UserChoice)
        {
            if (i_UserChoice != "Yes" && i_UserChoice != "No")
            {
                throw new ArgumentException("Only Yes or No!");
            }
        }

        private static void CargoCapacityValidating(string i_UserInput)
        {
            float numberForParse;

            if (!float.TryParse(i_UserInput, out numberForParse))
            {
                throw new FormatException("Wrong input");
            }

            if (numberForParse < 0)
            {
                throw new ValueOutOfRangeException(3000f, 0f);
            }
        }


        public bool HasCargo
        {
            get
            {
                return m_HasCargo;
            }
            set
            {
                m_HasCargo = value;
            }
        }
        public float CargoCapacity
        {
            get
            {
                return m_CargoCapacity;
            }
            set
            {
                m_CargoCapacity = value;
            }
        }
    }
}
