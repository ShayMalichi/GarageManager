using System;

namespace GarageManager
{
    public class FuelMotorcycle : Motorcycle
    {
        protected FuelEngine m_FuelEngine;
        protected eFuelType FuelType;
        private static float MAX_TANK = 5.4f;



        public FuelMotorcycle(string i_PlateNumber, string i_Model, float i_EnergyPrecentege, float i_Tiers,string i_TiresCompany, string i_Lisence, int i_EngineSize, eFuelType i_FuelType) :
             base(i_PlateNumber, i_Model, i_EnergyPrecentege, i_Tiers, i_TiresCompany, i_Lisence, i_EngineSize)
        {
            this.EngineType = eEngineType.Fuel;
            this.m_FuelEngine = new FuelEngine(i_EnergyPrecentege, MAX_TANK);
            this.FuelType = i_FuelType;
        }

        public static float GET_MAX_TANK()
        {
            return MAX_TANK;
        }

        public FuelEngine getFuelEngine()
        {
            return this.m_FuelEngine;
        }

        public eFuelType getFuelType()
        {
            return FuelType;
        }

        public override string ToString()
        {

        string s = String.Format("Plate Number: {0}, Model: {1}, Engine: {2}, Tank Left: {3}, Type: {4}, Lisence: {5}, EngineSize: {6}, Fuel Type: {7}", m_PlateNumber, m_Model, m_FuelEngine.ToString(),
            m_EnergyPrecentege.ToString(), CarType.ToString(), m_LiscenseType.ToString(), m_EngineSize.ToString(), FuelType.ToString());

            return "Vehicle info: {" + s + "}";
        }
    }
}

