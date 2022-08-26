using System;
namespace GarageManager
{
    public class FuelTruck : Truck
    {
        FuelEngine m_FuelEngine;
        private eFuelType FuelType;
        private static float MAX_TANK = 135f;

        public FuelTruck(string i_PlateNumber, string i_Model, float i_EnergyPrecentege, float i_Tiers, string i_TiersCompany, bool i_IsRefriege, float i_MaxCargo, eFuelType i_FuelType):
            base(i_PlateNumber, i_Model, i_EnergyPrecentege, i_Tiers, i_TiersCompany, i_IsRefriege, i_MaxCargo)

        {
            this.EngineType = eEngineType.Fuel;
            this.m_FuelEngine = new FuelEngine(i_EnergyPrecentege, MAX_TANK);
            this.FuelType = i_FuelType;
        }

        public FuelEngine getFuelEngine()
        {
            return this.m_FuelEngine;
        }

        public static float GET_MAX_TANK()
        {
            return MAX_TANK;
        }
        public override string ToString()
        {

        string s = String.Format("Plate Number: {0}, Model: {1}, Engine: {2}, Tank Left: {3}, Type: {4}, Include Cooling: {5}, Cargo: {6}, Fuel Type: {7}", m_PlateNumber, m_Model, m_FuelEngine.ToString(),
                m_EnergyPrecentege.ToString(), CarType.ToString(), m_IncludeCooling.ToString(), m_MaxCargo.ToString(), FuelType.ToString());

            return "Vehicle info: {" + s + "}";
        }

    }
}

