using System;
namespace GarageManager
{
    public abstract class Vehicle
    {
        protected string m_Model;
        protected string m_PlateNumber;
        protected float m_EnergyPrecentege;
        protected Tier[] m_Tiers;
        protected eEngineType EngineType;
        protected eCarType CarType;

        public void setEnergyPrecentege(float i_Amount)
        {
            this.m_EnergyPrecentege = i_Amount;
        }

        public float getEnergyPrecentege()
        {
            return m_EnergyPrecentege;
        }

        protected Tier[] MakeTiers(float i_Wheels, int i_MaxPressure, int i_NumberOfTires, string i_TiersCompany)
        {
            Tier[] tiers = new Tier[i_NumberOfTires];
            for (int i = 0; i < tiers.Length; i++)
            {
                tiers[i] = new Tier(i_TiersCompany, i_Wheels, i_MaxPressure);
            }

            return tiers;
        }

        public eCarType getCarType()
        {
            return CarType;
        }

        public eEngineType getEngineType()
        {
            return EngineType;
        }

        public void fixAllTires()
        {
            for (int i = 0; i < m_Tiers.Length; i++)
            {
                m_Tiers[i].IncreaseTirePressureToMax();
             }
        }
 
        public string getPlateNumber()
        {
            return this.m_PlateNumber;
        }

        public string PrintTiers()
        {
            string s = "{";
            foreach (Tier tier in m_Tiers)
            {
                s += tier.ToString() + "\n "; 
            }
            return s + "}";
        }

        public static string GenereteValidVehicle()
        {
            string vehicletype = string.Empty;
            while (true)
            {
                try
                {
                    vehicletype = Console.ReadLine();
                    if (!vehicletype.ToLower().Equals("car") && !vehicletype.ToLower().Equals("truck") && !vehicletype.ToLower().Equals("motorcycle"))
                    {
                        throw new ArgumentException();
                    }
                    return vehicletype;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("ENTER ONLY MOTORCYCLE/CAR/TRUCK");
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }

        public static string ChecksForValidEngineSize()
        {
            string engineSize = String.Empty;
            while (true)
            {
                engineSize = Console.ReadLine();
                try
                {
                    if (Convert.ToInt32(engineSize) <= 0)
                    {
                        throw new ArgumentException();
                    }
                    return engineSize;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("please enter positive number");
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("TOO LARGE OF A NUMBER");
                    Console.WriteLine(e.Message);
                }
            }
        }


        public static eFuelType StringToFuelType(string i_CarState)
        {
            eFuelType fuelType = eFuelType.Electric;

            switch (i_CarState)
            {
                case "soler":
                    fuelType = eFuelType.Soler;
                    break;

                case "octan95":
                    fuelType = eFuelType.Octan95;
                    break;

                case "octan98":
                    fuelType = eFuelType.Octan98;
                    break;
                case "electric":
                    fuelType = eFuelType.Electric;
                    break;
            }

            return fuelType;
        }

        public static eCarState StringToCarState(string i_CarState)
        {
            eCarState state = eCarState.Fixed;

            switch (i_CarState)
            {
                case "fixing":
                    state = eCarState.Fixing;
                    break;

                case "fixed":
                    state = eCarState.Fixed;
                    break;

                case "paid":
                    state = eCarState.Paid;
                    break;
            }

            return state;
        }

    }

    public enum eEngineType
    {
        Electric,
        Fuel
    }
}

