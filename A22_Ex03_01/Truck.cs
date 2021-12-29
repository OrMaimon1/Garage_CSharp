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
        private const string k_DoesHaveCargoMessage = "Does the truck has cargo: ";
        private const string k_CargoCapacityMessage = "The Cargo capacity is: ";

        public Truck(string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPressureForWheels, Engine i_Engine)
            : base(i_LicenseNumber, i_NumberOfWheels)
        {
            CreateTheWheels(i_MaxAirPressureForWheels, i_NumberOfWheels);
            Engine = i_Engine;
        }



        public override Hashtable FetchUniqueInfo()
        {
            Hashtable extraInfoMenu = new Hashtable();

            extraInfoMenu.Add(k_DoesHaveCargoMessage, null);
            extraInfoMenu.Add(k_CargoCapacityMessage, null);

            return extraInfoMenu;
        }

        public override void UpdateUniqueInfo(string i_KeyMessage, string i_UserInput)
        {
            switch (i_KeyMessage)
            {
                case k_DoesHaveCargoMessage:
                    HasCargoValidation(i_UserInput); 
                    if (i_UserInput == "Yes")
                    {
                        m_HasCargo = true;
                    }

                    break;

                case k_CargoCapacityMessage:
                    CargoCapacityValidating(i_UserInput);
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
                throw new ValueOutOfRangeException( 0f);
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

        public override string DetailsOfVehicle()
        {
            string details = base.DetailsOfVehicle();
            details += String.Format(@"Has Cargo: {0}
Cargo Capacity: {1}" , HasCargo , CargoCapacity);
            return details;
        }
    }
}
