using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A22_Ex03_01;

namespace Ex03.ConsoleUI
{
    class UiManager
    {
        private Garage m_Garage;

        public UiManager()
        {
            m_Garage = new Garage();
        }
        private Garage Garage
        {
            get
            {
                return m_Garage;
            }
        }

        public void AddVehicle()
        {
            Console.WriteLine("Enter the license number of the vehicle (7 digits)");
            string licenseNumber = Console.ReadLine();
            if(Garage.VehicleExists(licenseNumber))
            {
                Garage.AddExistingVehicle(licenseNumber);
            }
            else
            {
                Console.WriteLine("Please choose vehicle type: ");
                eVehicleType vehicleType;
                Enum.TryParse(Console.ReadLine(), out vehicleType);

                FillGeneralInfo();
            }
        }

        public void FillGeneralInfo()
        {
            string
        }
    }
}
