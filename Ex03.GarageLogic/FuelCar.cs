using System;
namespace GarageManager
{
    public class FuelCar : Car
    {
        private FuelEngine m_FuelEngine;
        private eFuelType FuelType;
        private static float MAX_TANK = 52f;

        public FuelCar(string i_PlateNumber, string i_Model, float i_EnergyPrecentege, float i_Tiers, string i_TiersCompany, string i_color, int i_numberOfDoors, eFuelType i_FuelType) :
            base(i_PlateNumber, i_Model, i_EnergyPrecentege, i_Tiers, i_TiersCompany, i_color, i_numberOfDoors)
        {

            this.EngineType = eEngineType.Fuel;
            this.m_FuelEngine = new FuelEngine(i_EnergyPrecentege, MAX_TANK);
            this.FuelType = i_FuelType;

        }

        public static float GET_MAX_TANK()
        {
            return MAX_TANK;
        }

        public eFuelType getFuelType()
        {
            return FuelType;
        }

        public FuelEngine getFuelEngine()
        {
            return this.m_FuelEngine;
        }

        public override string ToString()
        {

            string s = String.Format("Plate Number: {0}, Model: {1}, Engine: {2}, Tank Left: {3}, type: {4}, Color: {5}, Doors: {6}, Fuel Type: {7}", m_PlateNumber, m_Model, m_FuelEngine.ToString(),
            m_EnergyPrecentege.ToString(), CarType.ToString(), m_color.ToString(), m_numberOfDoors.ToString(), FuelType.ToString());

            return "Vehicle info: {" + s + "}";
        }



    }
}

