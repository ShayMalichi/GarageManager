using System;
namespace GarageManager
{
    public class FuelEngine : Engine
    {
        private float m_CurrentFuel;
        private float m_MaxFuel;

        public FuelEngine(float i_CurrentFuel, float i_MaxFuel)
        {
            this.m_CurrentFuel = i_CurrentFuel;
            this.m_MaxFuel = i_MaxFuel;
        }

        public override float IncreaseEnergy(float i_Amount)
        {
            if (m_CurrentFuel + i_Amount <= m_MaxFuel)
            {
                this.m_CurrentFuel += i_Amount;
            }
            return m_CurrentFuel;
        }


        public override string ToString()
        {
            return "Fuel";
        }
    }

    public enum eFuelType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98,
        Electric
    }
}

