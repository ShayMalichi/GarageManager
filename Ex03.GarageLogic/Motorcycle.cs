using System;
using System.ComponentModel;

namespace GarageManager
{
    public abstract class Motorcycle : Vehicle
    {
        protected eLiscenseType m_LiscenseType;
        protected int m_EngineSize;
        protected static int NUMBER_OF_TIERS = 2;
        protected static int MAX_PRESSURE = 31;


        public Motorcycle(string i_PlateNumber, string i_Model, float i_EnergyPrecentege, float i_Tiers, string i_TiresCompany, string i_Lisence, int i_EngineSize)
        {
            this.CarType = eCarType.Morotcycle;
            this.m_PlateNumber = i_PlateNumber;
            this.m_Model = i_Model;
            this.m_EnergyPrecentege = i_EnergyPrecentege;
            this.m_Tiers = MakeTiers(i_Tiers, getMAX_PRESSURE(), NUMBER_OF_TIERS, i_TiresCompany);
            this.m_LiscenseType = LisentSet(i_Lisence);
            this.m_EngineSize = i_EngineSize;
        }

        public static int getMAX_PRESSURE()
        {
            return MAX_PRESSURE;
        }

        public static string ValidLisenceChecker(string i_Liscense)
        {
            while (true)
            {
                i_Liscense = Console.ReadLine();
                try
                {
                    if (!i_Liscense.Equals("A") && !i_Liscense.Equals("AA") && !i_Liscense.Equals("B1") && !i_Liscense.Equals("BB"))
                    {
                        throw new ArgumentException();
                    }
                    return i_Liscense;
                }

                catch (ArgumentException e)
                {
                    Console.WriteLine("Please enter A/AA/B1/BB");
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }


        public static eLiscenseType LisentSet(string i_Liscense)
        {
            eLiscenseType Liscense = eLiscenseType.A;
            if(i_Liscense.Equals("A") && i_Liscense.Equals("AA") && i_Liscense.Equals("A") && i_Liscense.Equals("AA"))
            switch (i_Liscense)
            {
                case "A":
                    Liscense = eLiscenseType.A;
                    break;

                case "AA":
                    Liscense = eLiscenseType.AA;
                    break;

                case "B1":
                    Liscense = eLiscenseType.B1;
                    break;

                case "BB":
                    Liscense = eLiscenseType.BB;
                    break;
            }

            return Liscense;
        }


    }

    public enum eLiscenseType
    {
        A,
        AA,
        B1,
        BB
    }
}

