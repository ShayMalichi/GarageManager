using System;
namespace GarageManager
{
    public class VehicleMaker
    {
        public static FuelCar MakeFuelCar(string m_model, string i_PlateNumber, float i_EnergyPrecentege, float i_Tiers, string i_TiersCompany, string i_color, int i_numberOfDoors, eFuelType i_FuelType) 
        {
            FuelCar fuelCar = new FuelCar(i_PlateNumber, m_model, i_EnergyPrecentege, i_Tiers, i_TiersCompany, i_color, i_numberOfDoors, i_FuelType);
            return fuelCar;
        }

        public static ElectricCar MakeElectricCar(string m_model, string i_PlateNumber, float i_EnergyPrecentege, float i_Tiers, string i_TiersCompany, string i_color, int i_numberOfDoors, eFuelType i_FuelType)
        {
            ElectricCar electricCar = new ElectricCar(i_PlateNumber, m_model, i_EnergyPrecentege, i_Tiers, i_TiersCompany, i_color, i_numberOfDoors, i_FuelType);
            return electricCar;
        }

        public static FuelMotorcycle MakeFuelMotorcycle(string m_model, string i_PlateNumber, float i_EnergyPrecentege, float i_Tiers, string i_TiersCompany, string i_Lisence, int i_EngineSize, eFuelType i_FuelType)
        {
            FuelMotorcycle fuelMotorcycle = new FuelMotorcycle(i_PlateNumber, m_model, i_EnergyPrecentege, i_Tiers, i_TiersCompany, i_Lisence, i_EngineSize, i_FuelType);
            return fuelMotorcycle;
        }

        public static ElectricMotorcycle MakeElectricMotorcycle(string m_model, string i_PlateNumber, float i_EnergyPrecentege, float i_Tiers, string i_TiersCompany, string i_Lisence, int i_EngineSize, eFuelType i_FuelType)
        {
            ElectricMotorcycle electricMotorcycle = new ElectricMotorcycle(i_PlateNumber, m_model, i_EnergyPrecentege, i_Tiers, i_TiersCompany, i_Lisence, i_EngineSize, i_FuelType);
            return electricMotorcycle;
        }

        public static FuelTruck MakeFuelTruck(string m_model, string i_PlateNumber, float i_EnergyPrecentege, float i_Tiers, string i_TiersCompany, bool i_Refridge, float i_MaxCargo,eFuelType i_FuelType)
        {
            FuelTruck fuelTruck = new FuelTruck(i_PlateNumber, m_model, i_EnergyPrecentege, i_Tiers, i_TiersCompany, i_Refridge, i_MaxCargo, i_FuelType);
            return fuelTruck;
        }
    }
}
