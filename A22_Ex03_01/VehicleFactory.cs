using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace A22_Ex03_01
{
    public class VehicleFactory
    {
        //need to do with static func' and with switch with enum
        

        public static Vehicle AddVehicle(eVehicleType i_VehicleType, string i_VehicleModel, string i_LicenseNumber, float i_EnergySourceLeft, 
                                      List<Wheel> i_Wheels, Engine i_Engine, InfoOnCar i_InfoOnCar)
        {
            Vehicle newVehicle = null;
            switch(i_VehicleType)
            {
                case eVehicleType.FuelMotorcycle:
                    FuelEngine motorcycleFuelEngine = new FuelEngine(5.8f, 0, eFuelType.Octan98);
                    newVehicle = new Motorcycle(i_VehicleModel, i_LicenseNumber , i_EnergySourceLeft, i_Wheels, motorcycleFuelEngine, i_InfoOnCar);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    ElectricEngine motorcycleElectricEngine = new ElectricEngine(2.3f, 0);
                    newVehicle = new Motorcycle(i_VehicleModel, i_LicenseNumber, i_EnergySourceLeft, i_Wheels, motorcycleElectricEngine, i_InfoOnCar);
                    break;
                case eVehicleType.FuelCar:
                    FuelEngine carFuelEngine = new FuelEngine(48,0,eFuelType.Octan95);
                    newVehicle = new Car(i_VehicleModel, i_LicenseNumber, i_EnergySourceLeft, i_Wheels, carFuelEngine, i_InfoOnCar);
                    break;
                case eVehicleType.ElectricCar:
                    ElectricEngine carElectricEngine = new ElectricEngine(2.6f,0);
                    newVehicle = new Car(i_VehicleModel, i_LicenseNumber, i_EnergySourceLeft, i_Wheels, carElectricEngine, i_InfoOnCar);
                    break;
                case eVehicleType.Truck:
                    FuelEngine truckFuelEngine= new FuelEngine(130, 0 ,eFuelType.Solar);
                    newVehicle = new Truck(i_VehicleModel, i_LicenseNumber, i_EnergySourceLeft, i_Wheels, truckFuelEngine, i_InfoOnCar);
                    break;
                default:
                    throw new Exception();
            }

            return newVehicle;
        }

        public static void AddWheels(eVehicleType i_VehicleType, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {

        }


    }
}
