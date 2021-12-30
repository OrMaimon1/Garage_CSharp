using System;


namespace A22_Ex03_01
{
    public class VehicleFactory
    {
        /// car const info
        private const float k_wheelPressureForCars = 29;
        private const float k_FuelCarMaxTankCapacity = 48f;
        private const byte k_NumberOfWheelsForCars = 4;
        private const float k_ElectricalCarMaxBatteryLife = 2.6f;
        /// motorcycle const info
        private const float k_wheelPressureForMotorycle = 30;
        private const float k_FuelMotorcycleMaxTankCapacity = 5.8f;
        private const byte k_NumberOfWheelsForMotorcycle = 2;
        private const float k_ElectricalMotorcycleMaxBatteryLife = 2.3f;
        /// truck const info
        private const float k_wheelPressureForTrucks = 25;
        private const float k_TruckMaxTankCapacity = 130f;
        private const byte k_NumberOfWheelsForTruck = 16;
        public static Vehicle CreateVehicle(string i_UserChoice, string i_LicenseNumber)
        {
            eVehicleType userChoiceForVehicleType;
            Vehicle newVehicle = null;
            userChoiceForVehicleType = (eVehicleType)Enum.Parse(typeof(eVehicleType), i_UserChoice);
            switch (userChoiceForVehicleType)
            {
                case eVehicleType.FuelCar:
                    Engine carFuelEngine = new FuelEngine(k_FuelCarMaxTankCapacity,0f, eFuelType.Octan95);
                    newVehicle = new Car(i_LicenseNumber, k_NumberOfWheelsForCars,k_wheelPressureForCars,carFuelEngine);
                    break;
                case eVehicleType.FuelMotorcycle:
                    Engine motorcycleFuelEngine = new FuelEngine(k_FuelMotorcycleMaxTankCapacity,0,eFuelType.Octan98);
                    newVehicle = new Motorcycle(i_LicenseNumber, k_NumberOfWheelsForMotorcycle,k_wheelPressureForMotorycle,motorcycleFuelEngine);
                    break;
                case eVehicleType.Truck:
                    Engine truckFuelEngine = new FuelEngine(k_TruckMaxTankCapacity,0, eFuelType.Solar);
                    newVehicle = new Truck(i_LicenseNumber,k_NumberOfWheelsForTruck,k_wheelPressureForTrucks,truckFuelEngine);
                    break;
                case eVehicleType.ElectricCar:
                    Engine carElectricEngine = new ElectricEngine(k_ElectricalCarMaxBatteryLife,0);
                    newVehicle = new Car(i_LicenseNumber, k_NumberOfWheelsForCars, k_wheelPressureForCars,carElectricEngine); //need to clean
                    break;
                case eVehicleType.ElectricMotorcycle:
                    Engine motorcycleElectricEngine = new ElectricEngine(k_ElectricalMotorcycleMaxBatteryLife, 0);
                    newVehicle = new Motorcycle(i_LicenseNumber, k_NumberOfWheelsForMotorcycle, k_wheelPressureForMotorycle,motorcycleElectricEngine); // need to clean
                    break;
            }
            return newVehicle;
        }
    }
}
