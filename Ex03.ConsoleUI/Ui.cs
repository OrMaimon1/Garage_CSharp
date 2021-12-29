using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
             eActionSelector action;
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
             Console.WriteLine(userMenusb);
             Enum.TryParse(Console.ReadLine(), out action);
             PreformUserChoice(action);
         }

         private void PreformUserChoice(eActionSelector i_UserInput)
         {
             switch(i_UserInput)
             {
                case eActionSelector.EnterYourVehicle:
                    UiManager.AddVehicle();
                    break;
                case eActionSelector.ChangeVehicleState:
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
         }




    }
}
