using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class Ui
    {
        private UiManeger m_UiManeger;

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

         public void Start()
         {
             int userInput;
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
             int.TryParse(Console.ReadLine(), out userInput);
             //need to check input with func

             switch(userInput)
             {
                case eActionSelector.EnterYourVehicle:
                    break;
             }
             

         }


    }
}
