using System;
using System.Collections.Generic;

namespace GarageManager
{
    public class Garage 
    {
        private List<VehicleCard> m_VehiclesInGarage;
        private Dictionary<string, VehicleCard> GarageDiary;

        public Garage()
        {
            this.m_VehiclesInGarage = new List<VehicleCard>();
            this.GarageDiary = new Dictionary<string, VehicleCard>();
        }

        public bool GarageEmpty()
        {
            return this.m_VehiclesInGarage.Count == 0;
        }

        public bool isVehicleInGarage(string i_PlateNumber)
        {
            return this.GarageDiary.ContainsKey(i_PlateNumber);
        }
    
        public void addVehicle(Vehicle vehicle,string i_PlateNumber, string i_Name, string i_PhoneNumber, eFuelType i_fuelType)
        {
            VehicleCard card = new VehicleCard(vehicle, i_Name, i_PhoneNumber, eCarState.Fixing , i_fuelType);
            this.GarageDiary.Add(i_PlateNumber, card);
            this.m_VehiclesInGarage.Add(card);
        }

        public void DisplayPlateNumbersInGarage(int input)
        {
            foreach (VehicleCard vehicleCard in m_VehiclesInGarage)
            {
                switch (input)
                {
                    case 1:
                        Console.WriteLine(vehicleCard.getVehicle().getPlateNumber());
                        break;

                    case 2:
                        if (vehicleCard.GetCarState() == eCarState.Fixing)
                        {
                            Console.WriteLine(vehicleCard.getVehicle().getPlateNumber());
                        }

                        break;

                    case 3:
                        if (vehicleCard.GetCarState() == eCarState.Fixed)
                        {
                            Console.WriteLine(vehicleCard.getVehicle().getPlateNumber());
                        }

                        break;

                    case 4:
                        if (vehicleCard.GetCarState() == eCarState.Paid)
                        {
                            Console.WriteLine(vehicleCard.getVehicle().getPlateNumber());
                        }

                        break;
                }
            }
        }
     
        public void ChangeVehicleStatus(string i_PlateNumber, eCarState carState)
        {
            this.GarageDiary[i_PlateNumber].setCarState(carState); 
        }

        public void IncreaseTierPressureToMax(string i_PlateNumber)
        {
            this.GarageDiary[i_PlateNumber].getVehicle().fixAllTires();
        }

        public void IncreaseFuel(string i_PlateNumber, eFuelType fuelType, float i_Amount)
        {         
                Vehicle vehicle = GarageDiary[i_PlateNumber].getVehicle();
                eCarType c = vehicle.getCarType();
                float newEnergy = 0f;

                switch (c)
                {
                    case eCarType.Car:
                        FuelCar fuelCar = (FuelCar)vehicle;
                        newEnergy = fuelCar.getFuelEngine().IncreaseEnergy(i_Amount);
                        fuelCar.setEnergyPrecentege(newEnergy);
                        break;
                    case eCarType.Truck:
                        FuelTruck fuelTruck = (FuelTruck)vehicle;
                        newEnergy = fuelTruck.getFuelEngine().IncreaseEnergy(i_Amount);
                        fuelTruck.setEnergyPrecentege(newEnergy);
                        break;
                    case eCarType.Morotcycle:

                        FuelMotorcycle fuelMotorcycle = (FuelMotorcycle)vehicle;
                        newEnergy = fuelMotorcycle.getFuelEngine().IncreaseEnergy(i_Amount);
                        fuelMotorcycle.setEnergyPrecentege(newEnergy);
                        break;
                }
        }
        
        public void IncreaseBattery(string i_PlateNumber, float i_Minutes)
        {
            VehicleCard card = GarageDiary[i_PlateNumber];
            Vehicle vehicle = GarageDiary[i_PlateNumber].getVehicle();
            vehicle.setEnergyPrecentege(i_Minutes + vehicle.getEnergyPrecentege());
        }
        
        public void DisplayAllDitails(string i_PlateNumber)
        {
            Console.WriteLine(this.GarageDiary[i_PlateNumber].ToString());
        }

        public Dictionary<string, VehicleCard> getGarageDiary()
        {
            return this.GarageDiary;
        }

        public bool ExistsElectricVhicle()
        {
            bool v_Exists = false;

            foreach (VehicleCard vehicleCard in m_VehiclesInGarage)
            {
                if (vehicleCard.GetEngineType() == eEngineType.Electric)
                {
                    return true;
                }
            }

            return v_Exists;
        }

        public bool ExistsFuelVhicle()
        {
            bool v_Exists = false;

            foreach (VehicleCard vehicleCard in m_VehiclesInGarage)
            {
                if (vehicleCard.GetEngineType() == eEngineType.Fuel)
                {
                    return true;
                }
            }

            return v_Exists;
        }

        public static string ChecksForValidFuel(Vehicle vehicle, eFuelType i_FuelType)
        {
            vehicle.getEngineType();
            string fuel = string.Empty;

            while (true)
            {
                fuel = Console.ReadLine();
                try
                {
                    if (vehicle.getEngineType() == eEngineType.Electric || !fuel.ToLower().Equals(i_FuelType.ToString().ToLower()))
                    {
                        throw new ArgumentException();
                    }
                    Console.WriteLine("THATS THE RIGHT FUEL TYPE");
                    return fuel.ToLower();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(@"NOT VALID FUEL TYPE OR NOT VALID ENGINE TYPE
you need to enter Soler/Octan95/Octan98");
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static string ChecksForValidPlateNumber(Garage garage)
        {
            string plateNumber = String.Empty;
            while (true)
            {
                plateNumber = Console.ReadLine();
                try
                {
                    if (!garage.isVehicleInGarage(plateNumber))
                    {
                        throw new ArgumentException();
                    }
                    return plateNumber;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("THIS PLATE IS NOT IN GARAGE!!");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("THOSE VEHICLES ARE CURRENTLY IN GARAGE");
                    garage.DisplayPlateNumbersInGarage(1);
                    continue;
                }
            }
        }
    }
}

