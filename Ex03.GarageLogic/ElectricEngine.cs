using System;
namespace GarageManager
{
    public class ElectricEngine : Engine
    {
        private float m_BatteryLeft;
        protected static float m_MaxBatteryDistance = 4.5f;
        

        public ElectricEngine(float i_BatteryLeft)
        {
            this.m_BatteryLeft = i_BatteryLeft;
            
        }


        public override float IncreaseEnergy(float i_Amount)
        {
            if (m_BatteryLeft + i_Amount <= m_MaxBatteryDistance)
            {
                this.m_BatteryLeft += i_Amount;
            }
            return m_BatteryLeft;
        }

        public override string ToString()
        {
            return "Electric";
        }



    }






}

