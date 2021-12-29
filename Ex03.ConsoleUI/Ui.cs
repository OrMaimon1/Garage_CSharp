using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A22_Ex03_01;

namespace Ex03.ConsoleUI
{
    public class Ui
    {
        private UiManager m_UiManeger;

         private enum eActionSelector
        {
            EnterYourVehicle = 1,
            ShowLicensePlate,
            ChangeVehicleState,
            InflateWheels,
            ReFuelVehicle,
            ReChargeVehicle,
            ShowVehicle,
            Exit
        }

         private UiManager UiManager
         {
             get
             {
                 return m_UiManeger;
             }
         }

        public void Start()
        {
            bool resume = true;
            eActionSelector action;
            int checkInput;
            string userPickedNumber;
            StringBuilder userMenusb = new StringBuilder();
            userMenusb.AppendLine("Enter the number of the action you want to preform: ");
            userMenusb.AppendLine("1.Enter your vehicle to the garage");
            userMenusb.AppendLine("2.View LicensePlate of the vehicle in the garage");
            userMenusb.AppendLine("3.change Vehicle state in garage");
            userMenusb.AppendLine("4.inflate Vehicle wheels");
            userMenusb.AppendLine("5.Refuel Vehicle ");
            userMenusb.AppendLine("6.Recharge Vehicle");
            userMenusb.AppendLine("7.show Vehicle details");
            userMenusb.AppendLine("8.Quit");
            while (resume)
            {
                Console.WriteLine(userMenusb);
                userPickedNumber = Console.ReadLine();
                Enum.TryParse(userPickedNumber, out action);
                if (!userPickedNumber.All(char.IsDigit))
                {
                    throw new FormatException("invalid input");
                }
                int.TryParse(userPickedNumber, out checkInput);
                if (checkInput < 0 || 8 < checkInput)
                {
                    throw new ValueOutOfRangeException(0,8);
                }
                if(checkInput == 8)
                {
                    resume = false;
                }
                PreformUserChoice(action);
            }
        }

        private void PreformUserChoice(eActionSelector i_UserInput)
        {
            switch (i_UserInput)
            {
                case eActionSelector.EnterYourVehicle:
                    UiManager.AddVehicle();
                    break;
                case eActionSelector.ChangeVehicleState:
                    UiManager.ChargeVehicle();
                    break;
                case eActionSelector.InflateWheels:
                    
                    break;
                case eActionSelector.ShowLicensePlate:
                    break;
                case eActionSelector.ReFuelVehicle:
                    break;
                case eActionSelector.ReChargeVehicle:
                    break;
                case eActionSelector.ShowVehicle:
                    break;
            }

            if(expr)
            {
                
            }
        }




    }
}
