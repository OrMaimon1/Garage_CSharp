using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A22_Ex03_01
{
    //temp stat need to check if every enum need a class
    public enum eVehicleState
    {
        None,
        Fixing,
        Fixed,
        Payed,

    }
    public enum eLicenseType
    {
        None,
        A,
        A2,
        AA,
        B
    }
    public enum eColor
    {
        None,
        Red,
        White,
        Black,
        Blue
    }
    public enum eFuelType
    {
        None,
        Octan98,
        Octan96,
        Octan95,
        Solar
    }

    public enum eVehicleType
    {
        None,
        ElectricMotorcycle,
        FuelMotorcycle,
        ElectricCar,
        FuelCar,
        Truck
    }

    public enum eNumberOfDoors
    {
        None,
        TwoDoors,
        ThreeDoors,
        FourDoors,
        FiveDoors
    }
}
