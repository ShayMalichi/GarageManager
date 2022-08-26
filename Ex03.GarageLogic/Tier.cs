using System;
namespace GarageManager
{
    public class Tier
    {
        private string m_Manufacturer;
        private float m_CurrentPressure;
        private float m_MaxPressure;

        public Tier(string i_Manufacturer,float i_CurrentPressure, float i_MaxPressure)
        {
            this.m_CurrentPressure = i_CurrentPressure;
            this.m_Manufacturer = i_Manufacturer;
            this.m_MaxPressure = i_MaxPressure;
        }

        public void IncreaseTirePressureToMax()
        {
            float PressureMissing = m_MaxPressure - m_CurrentPressure;
            this.m_CurrentPressure += PressureMissing; 
        }

        public override string ToString()
        {
            string s = string.Format("Tier Brand: {0}, Pressure: {1}, Max Pressure: {2}", m_Manufacturer, m_CurrentPressure.ToString(), m_MaxPressure.ToString());
            return s;
        }
    }
}

