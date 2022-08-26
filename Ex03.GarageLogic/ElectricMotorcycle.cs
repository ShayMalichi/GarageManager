using System;
namespace GarageManager
{
    public class ElectricMotorcycle : Motorcycle
    {
        private ElectricEngine m_ElectricEngine;
        private static float MAX_BATTERY = 2.8f;
        private eFuelType FuelType;

        public ElectricMotorcycle(string i_PlateNumber, string i_Model, float i_EnergyPrecentege, float i_Tiers, string i_TiersCompany , string i_Lisence, int i_EngineSize , eFuelType i_FuelType):
            base(i_PlateNumber, i_Model, i_EnergyPrecentege, i_Tiers, i_TiersCompany, i_Lisence, i_EngineSize)
        {
            this.EngineType = eEngineType.Electric;
            this.m_ElectricEngine = new ElectricEngine(i_EnergyPrecentege);
            this.FuelType = i_FuelType;
        }

        public static float GET_MAX_BATTERY()
        {
            return MAX_BATTERY;
        }

        public float getMAX_BATTERY()
        {
            return MAX_BATTERY;
        }


        public override string ToString()
        {
                string s = String.Format("Plate Number: {0}, Model: {1}, Engine: {2}, Battery: {3}, Type: {4}, Lisence: {5}, EngineSize: {6}", m_PlateNumber, m_Model, m_ElectricEngine.ToString(),
                m_EnergyPrecentege.ToString(), CarType.ToString(), m_LiscenseType.ToString(), m_EngineSize.ToString());

                return "Vehicle info: {" + s + "}";
        }

    }
}

