using System;

namespace GarageManager
{
    public abstract class Car : Vehicle
    {
        protected eColor m_color;
        protected int m_numberOfDoors;
        protected static int NUMBER_OF_TIERS = 4;
        protected static int MAX_PRESSURE = 27;

        public Car(string i_PlateNumber, string i_Model, float i_EnergyPrecentege, float i_Tiers, string i_TiersCompany, string i_color, int i_numberOfDoors)
        {
            this.CarType = eCarType.Car;
            this.m_PlateNumber = i_PlateNumber;
            this.m_Model = i_Model;
            this.m_EnergyPrecentege = i_EnergyPrecentege;
            this.m_Tiers = MakeTiers(i_Tiers, getMAX_PRESSURE(), NUMBER_OF_TIERS, i_TiersCompany);
            this.m_color = StringToColor(i_color);
            this.m_numberOfDoors = i_numberOfDoors;

        }

        public static int getMAX_PRESSURE()
        {
            return MAX_PRESSURE;
        }

        public static string GenereteValidColor()
        {
            string ValidColor = string.Empty;
            while (true)
            {
                try
                {
                    ValidColor = Console.ReadLine();
                    if (!ValidColor.ToLower().Equals("black") && !ValidColor.ToLower().Equals("blue") && !ValidColor.ToLower().Equals("grey") && !ValidColor.ToLower().Equals("white"))
                    {
                        throw new ArgumentException();
                    }
                    return ValidColor;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("ENTER ONLY BLACK/WHITE/GREY/BLUE");
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("ONLY LETTERS");
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static eColor StringToColor(string i_Color)
        {
            eColor color = eColor.WHITE;
            switch (i_Color)
            {
                case "BLACK":
                    color = eColor.BLACK;
                    break;

                case "BLUE":
                    color = eColor.BLUE;
                    break;

                case "GREY":
                    color = eColor.GREY;
                    break;

                case "WHITE":
                    color = eColor.WHITE;
                    break;
            }
            return color;
        }

    }

    public enum eColor
    {
        GREY,
        BLACK,
        WHITE,
        BLUE
    }

    public enum eNumberOfDoors
    {
        TWO,
        THREE,
        FOUR,
        FIVE
    }



}

