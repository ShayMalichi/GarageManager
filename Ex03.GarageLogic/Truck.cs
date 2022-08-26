using System;
namespace GarageManager
{
    public abstract class Truck : Vehicle
    {
        protected bool m_IncludeCooling;
        protected float m_MaxCargo;
        protected static int NUMBER_OF_TIERS = 16;
        protected static int MAX_PRESSURE = 25;

        public Truck(string i_PlateNumber, string i_Model, float i_EnergyPrecentege, float i_Tiers, string i_TiersCompany, bool i_IsRefriege, float i_MaxCargo)
        {
            this.CarType = eCarType.Truck;
            this.m_PlateNumber = i_PlateNumber;
            this.m_Model = i_Model;
            this.m_EnergyPrecentege = i_EnergyPrecentege;
            this.m_Tiers = MakeTiers(i_Tiers, getMAX_PRESSURE(), NUMBER_OF_TIERS, i_TiersCompany);
            this.m_IncludeCooling = i_IsRefriege;
            this.m_MaxCargo = i_MaxCargo;
        }

        public static int getMAX_PRESSURE()
        {
            return MAX_PRESSURE;
        }

        public static string ChecksForValidRefridge()
        {
            string i_isRefridge = string.Empty;

            while (true)
            {
                i_isRefridge = Console.ReadLine();
                try
                {
                    if (!i_isRefridge.ToLower().Equals("yes") && !i_isRefridge.ToLower().Equals("no"))
                    {
                        throw new ArgumentException();
                    }
                    return i_isRefridge;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("ENTER ONLY YES/NO");
                    Console.WriteLine(e.Message);
                }
           }
        }
    }
}

