﻿using System;
using System.Linq;
using System.Text;
using A22_Ex03_01;

namespace Ex03.ConsoleUI
{
    public class Ui
    {
        private UiManager m_UiManeger = new UiManager();
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
            userMenusb.AppendLine();
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
                int.TryParse(userPickedNumber, out checkInput);
                if (!userPickedNumber.All(char.IsDigit) || checkInput < 0 || 8 < checkInput)
                {
                    Console.WriteLine("please enter a number between 1-8 (include 1 and 8)"+Environment.NewLine);
                }
                else
                {
                    if (checkInput == 8)
                    {
                        resume = false;
                    }
                    PreformUserChoice(action);
                }
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
                    UiManager.UpdateVehicleState();
                    break;
                case eActionSelector.InflateWheels:
                    UiManager.InflateWheelsToMax();
                    break;
                case eActionSelector.ShowLicensePlate:
                    UiManager.ViewVehicleLicense();
                    break;
                case eActionSelector.ReFuelVehicle:
                    UiManager.FuelVehicle();
                    break;
                case eActionSelector.ReChargeVehicle:
                    UiManager.ChargeVehicle();
                    break;
                case eActionSelector.ShowVehicle:
                    UiManager.GetVehicleDetails();
                    break;
                case eActionSelector.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
