using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;
using GarageManager;
using Microsoft.VisualBasic.FileIO;


namespace ConsoleUI
{
    class Program
    {
        public static void Main(string[] args)
        {
            Garage garage = new Garage();
            string input = string.Empty;
            while (!input.Equals("Q"))
            {
                Menu(garage);
                Console.WriteLine("press any key to continue or Q to end");
                input = Console.ReadLine();
            }

        }

        public static void Menu(Garage garage)
        {
            Console.WriteLine("WELCOME TO THE GARAGE:");
            Console.WriteLine(@"PLEASE CHOOSE THE OPTIONS:
PRESS 1 TO ADD VEHICLE TO GARAGE

PRESS 2 TO DISPLAY PLATE NUMBERS IN GARAGE

PRESS 3 TO CHANGE VEHICLE STATUS IN GARAGE

PRESS 4 TO INCREASE TIRE PRESSURE

PRESS 5 TO ADD FUEL TO FUELED CAR

PRESS 6 TO CHARGE ELECTRIC CAR

PRESS 7 TO DISPLAY THE VEHICLE DETAILS IN GARAGE");

            int pick = Convert.ToInt32(checksForValidInput(0, 7));
            switch (pick)
            {
                case 1:
                    Console.WriteLine("WHATS THE PLATE NUMBER OF THE CAR YOU WANT TO ENTER TO GARAGE?:");
                    string plate = Console.ReadLine();
                    addVehicleInMenu(plate,garage);
                    break;

                case 2:
                    if (garage.GarageEmpty())
                    {
                        Console.WriteLine("SORRY GARAGE EMPTY..");
                        break;
                    }
                    Console.WriteLine(@"PRESS 1 TO DISPLAY ALL PLATE NUMBERS

PRESS 2 TO DISPLAY ALL FIXING PLATE NUMBERS

PRESS 3 TO DISPLAY ALL FIXED PLATE NUMBERS

PRESS 4 TO DISPLAY ALL PAID PLATE NUMBERS");
                    int input = Convert.ToInt32(checksForValidInput(0, 4));
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("ALL PLATES IN GARAGE");
                            garage.DisplayPlateNumbersInGarage(1);
                            break;
                        case 2:
                            Console.WriteLine("ALL PIXING PLATES IN GARAGE");
                            garage.DisplayPlateNumbersInGarage(2);
                            break;
                        case 3:
                            Console.WriteLine("ALL FIXED PLATES IN GARAGE");
                            garage.DisplayPlateNumbersInGarage(3);
                            break;
                        case 4:
                            Console.WriteLine("ALL PAID PLATES IN GARAGE");
                            garage.DisplayPlateNumbersInGarage(4);
                            break;
                    }
                    

                    break;

                case 3:
                    if (garage.GarageEmpty())
                    {
                        Console.WriteLine("SORRY GARAGE EMPTY..");
                        break;
                    }
                    
                    Console.WriteLine("WHATS THE PLATE NUMBER OF THE VEHICLE YOU WANT TO CHANGE STATUS TO?:");
                    string platenumber = Garage.ChecksForValidPlateNumber(garage);
                    Console.WriteLine("WHAT IS THE NEW STATUS DISIRED?:");
                    
                    string validState = VehicleCard.generateValidVehicleState();
                    eCarState carState = Vehicle.StringToCarState(validState);

                    garage.ChangeVehicleStatus(platenumber, carState);

                    Console.WriteLine("YOUR VEHICLE STATUS CHANGED SECCESFULY :)");
                    break;

                case 4:
                    if (garage.GarageEmpty())
                    {
                        Console.WriteLine("SORRY GARAGE EMPTY..");
                        break;
                    }
                    Console.WriteLine("WHATS THE PLATE NUMBER OF THE VEHICLE YOU WANT TO INCREASE TIERS PRESSURE TO?:");
                    platenumber = Garage.ChecksForValidPlateNumber(garage);
                    garage.IncreaseTierPressureToMax(platenumber);
                    Console.WriteLine("YOUR TIERS PRESSURE CHANGED SECCESFULY :)");
                    break;

                case 5:
                    if (garage.GarageEmpty())
                    {
                        Console.WriteLine("SORRY GARAGE EMPTY..");
                        break;
                    }
                    if (!garage.ExistsFuelVhicle())
                    {
                        Console.WriteLine("SORRY NO FUEL CARS..");
                        break;
                    }


                    Console.WriteLine("WHATS THE PLATE NUMBER OF THE VEHICLE YOU WANT TO INCREASE FUEL TO?:");
                    platenumber = Garage.ChecksForValidPlateNumber(garage);
                    Dictionary<string, VehicleCard> GarageDiary = garage.getGarageDiary();
                    Vehicle CurrentVehicle = GarageDiary[platenumber].getVehicle();

                    eFuelType CurrentVehicleFuelType = GarageDiary[platenumber].GetFuelType();
                    Console.WriteLine("WHATS THE TYPE OF FUEL YOU WANT TO FUEL IN?:");
                    string fuelAsString = Garage.ChecksForValidFuel(CurrentVehicle, CurrentVehicleFuelType);
                    eFuelType fuel = Vehicle.StringToFuelType(fuelAsString);
                    float amountOfFuel = 0;
                    float validOfFuel = 0;
                    switch (fuel)
                    {
                        case eFuelType.Octan95:
                            Console.WriteLine("ENTER THE AMOUNT YOU WANT TO FEUL:");
                            validOfFuel = FuelCar.GET_MAX_TANK() - CurrentVehicle.getEnergyPrecentege();
                            amountOfFuel = float.Parse(checksForValidInput(0, validOfFuel));
                            break;
                        case eFuelType.Octan98:
                            Console.WriteLine("ENTER THE AMOUNT YOU WANT TO FEUL:");
                            validOfFuel = 5.4f - CurrentVehicle.getEnergyPrecentege();
                            amountOfFuel = float.Parse(checksForValidInput(0, validOfFuel));
                            break;
                        case eFuelType.Soler:
                            Console.WriteLine("ENTER THE AMOUNT YOU WANT TO FEUL:");
                            validOfFuel = FuelTruck.GET_MAX_TANK() - CurrentVehicle.getEnergyPrecentege();
                            amountOfFuel = float.Parse(checksForValidInput(0, validOfFuel));
                            break;
                    }

                    garage.IncreaseFuel(platenumber, fuel , amountOfFuel);
                    Console.WriteLine("YOUR FUEL HAS BEEN INCREASED :)");
                    break;

                case 6:
                    if (garage.GarageEmpty())
                    {
                        Console.WriteLine("SORRY GARAGE EMPTY..");
                        break;
                    }

                    if (!garage.ExistsElectricVhicle())
                    {
                        Console.WriteLine("SORRY NO ELECTRIC CARS..");
                        break;
                    }
                    Console.WriteLine("WHATS THE PLATE NUMBER OF THE VEHICLE YOU WANT TO CHARGE BATTERY TO?:");

                    platenumber = Garage.ChecksForValidPlateNumber(garage);

                    Dictionary<string, VehicleCard> dictionary = garage.getGarageDiary();
                    Vehicle vehicle = dictionary[platenumber].getVehicle();
                    float ValidAmount = 0;
                    float ChargeAmount = 0;
                    eCarType type = vehicle.getCarType();
                    switch (type)
                    {
                        case eCarType.Car:
                            Console.WriteLine("ENTER THE AMOUNT YOU WANT TO CHARGE:");
                            ValidAmount = ElectricCar.GET_MAX_BATTERY() - vehicle.getEnergyPrecentege();
                            ChargeAmount = float.Parse(checksForValidInput(0, ValidAmount));

                            break;

                        case eCarType.Morotcycle:
                            Console.WriteLine("ENTER THE AMOUNT YOU WANT TO CHARGE:");
                            ValidAmount = ElectricMotorcycle.GET_MAX_BATTERY() - vehicle.getEnergyPrecentege();
                            ChargeAmount = float.Parse(checksForValidInput(0, ValidAmount));
                            break;
                    }
                    garage.IncreaseBattery(platenumber, ChargeAmount);
                    Console.WriteLine("YOUR BATTERY HAS BEEN INCREASED :)");
                    break;

                case 7:
                    if (garage.GarageEmpty())
                    {
                        Console.WriteLine("SORRY GARAGE EMPTY..");
                        break;
                    }
                    Console.WriteLine("WHATS THE PLATE NUMBER OF THE VEHICLE YOU WANT TO DISPLAY THE STATUS IN GARAGE?:");
                    platenumber = Garage.ChecksForValidPlateNumber(garage);
                    Console.WriteLine("YOUR VEHICLE STATUS INSIDE GARAGE:");
                    garage.DisplayAllDitails(platenumber);
                    
                    break;
            }



        }


        public static void addVehicleInMenu(string plateNumber, Garage garage)
        {
            if (garage.isVehicleInGarage(plateNumber))
            {
                Console.WriteLine("THIS CAR IS ALREADY IS GARAGE WE CHANGE THE STATUS TO FIXING");
            }
            else
            {


                Console.WriteLine("WHATS IS YOUR VEHICLE TYPE?:");
                string vehicletype = Vehicle.GenereteValidVehicle();


                Console.WriteLine("ENTER THE VEHICLE MODEL:");
                string model = Console.ReadLine();


                Console.WriteLine("ENTER THE TIERS MANIFACTURER:");
                string WheelBrand = Console.ReadLine();

                vehicletype = vehicletype.ToLower();
                string WheelPressure = string.Empty;
                Vehicle vehicle = null;
                eFuelType fuelType = eFuelType.Electric;
                switch (vehicletype)
                {
                    case "car":

                        Console.WriteLine("HOW MANY DOORS YOUR CAR HAS?");
                        string doors = checksForValidInput(0, 5);

                        Console.WriteLine("WHAT COLOR IS YOUR CAR?");
                        string color = Car.GenereteValidColor();



                        Console.WriteLine("WHATS THE PRESSURE OF WHEELS?");
                        WheelPressure = checksForValidInput(0, Car.getMAX_PRESSURE());



                        Console.WriteLine("WHATS YOURE ENGINE TYPE?");
                        string engineType = GenerateValidEngine();
                        engineType = engineType.ToLower();
                        string energyleft = string.Empty;
                        switch (engineType)
                        {
                            case "electric":

                                Console.WriteLine("WHATS YOUR CURRENT BATTERY?");
                                fuelType = eFuelType.Electric;
                                energyleft = checksForValidInput(0, ElectricCar.GET_MAX_BATTERY());
                                vehicle = VehicleMaker.MakeElectricCar(model, plateNumber, float.Parse(energyleft), float.Parse(WheelPressure), WheelBrand, color, Convert.ToInt32(doors), fuelType);
                                break;

                            case "fuel":
                                Console.WriteLine("WHATS YOUR CURRENT FUEL TANK?");
                                fuelType = eFuelType.Octan95;
                                energyleft = checksForValidInput(0, FuelCar.GET_MAX_TANK());
                                vehicle = VehicleMaker.MakeFuelCar(model, plateNumber, float.Parse(energyleft), float.Parse(WheelPressure), WheelBrand, color, Convert.ToInt32(doors), fuelType);
                                break;
                        }

                        break;




                    case "motorcycle":
                        Console.WriteLine("WHAT TYPE OF LISENCE YOUR MOTORCYCLE HAS?");
                        string Liscense = String.Empty;
                        Liscense = Motorcycle.ValidLisenceChecker(Liscense);

                        Console.WriteLine("WHATS THE MOTORCYCLE ENGINE SIZE?");

                        string sizeOfEngine = Vehicle.ChecksForValidEngineSize();
                        int engineSize = Convert.ToInt32(sizeOfEngine);


                        Console.WriteLine("WHATS THE PRESSURE OF WHEELS>");
                        WheelPressure = checksForValidInput(0, Motorcycle.getMAX_PRESSURE());


                        Console.WriteLine("WHATS YOURE ENGINE TYPE?");
                        engineType = GenerateValidEngine();
                        engineType = engineType.ToLower();
                        energyleft = string.Empty;

                        switch (engineType)
                        {
                            case "electric":

                                Console.WriteLine("WHATS YOUR CURRENT BATTERY?");
                                fuelType = eFuelType.Electric;
                                energyleft = checksForValidInput(0, ElectricMotorcycle.GET_MAX_BATTERY());
                                vehicle = VehicleMaker.MakeElectricMotorcycle(model, plateNumber, float.Parse(energyleft), float.Parse(WheelPressure), WheelBrand, Liscense, engineSize, fuelType);
                                break;

                            case "fuel":
                                fuelType = eFuelType.Octan98;
                                Console.WriteLine("WHATS YOUR CURRENT FUEL TANK?");
                                energyleft = checksForValidInput(0, FuelMotorcycle.GET_MAX_TANK());
                                vehicle = VehicleMaker.MakeFuelMotorcycle(model, plateNumber, float.Parse(energyleft), float.Parse(energyleft), WheelBrand, Liscense, engineSize, fuelType);

                                break;
                        }
                        break;


                    case "truck":
                        Console.WriteLine("WHATS THE TRUCK CARGO SIZE?");
                        string cargoSize = Vehicle.ChecksForValidEngineSize();


                        Console.WriteLine("IS THERE COOLING INSIDE CARGO?");
                        bool isfridge = false;
                        string isRefregerator = Truck.ChecksForValidRefridge();
                        if (isRefregerator.Equals("yes"))
                        {
                            isfridge = true;
                        }

                        Console.WriteLine("WHATS THE PRESSURE OF WHEELS");
                        WheelPressure = checksForValidInput(0, Truck.getMAX_PRESSURE());


                        Console.WriteLine("WHATS YOUR CURRENT FUEL TANK?");
                        fuelType = eFuelType.Soler;
                        energyleft = checksForValidInput(0, FuelTruck.GET_MAX_TANK());
                        vehicle = VehicleMaker.MakeFuelTruck(model, plateNumber, float.Parse(energyleft), float.Parse(WheelPressure), WheelBrand, isfridge, float.Parse(cargoSize), fuelType);
                        break;

                }

                Console.WriteLine("PLEASE ENTER YOUR NAME:");
                string name = Console.ReadLine();

                Console.WriteLine("PLEASE ENTER YOUR PHONE NUMBER:");
                string phone = Console.ReadLine();


                garage.addVehicle(vehicle, vehicle.getPlateNumber(), name, phone, fuelType);
                Console.WriteLine("YOUR VEHICLE HAS BEEN SIGHNED TO GARAGE SUCSSFULY :)");

            }
        }

        //validations
        public static string GenerateValidEngine()
        {
            string engineType = Console.ReadLine();
            while (!engineType.ToLower().Equals("electric") && !engineType.ToLower().Equals("fuel"))
            {
                Console.WriteLine("Please enter only Electric/Fuel:");
                engineType = Console.ReadLine();
            }
            return engineType;
        }
         


    public static string checksForValidInput(float i_Min, float i_Max)
        {
            string CurrentString = string.Empty;
            while (true)
            {
                CurrentString = Console.ReadLine();
                try
                {
                    if (float.Parse(CurrentString) > i_Max || float.Parse(CurrentString) <= i_Min)
                    {
                        throw new ValueOutOfRangeException(i_Min, i_Max);
                    }
                    return CurrentString;
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("ONLY NUMBERS");
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
    }
}

