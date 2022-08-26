using System;

namespace GarageManager
{
    public class VehicleCard
    {
        private Vehicle m_Vehicle;
        private string m_CarOwner;
        private string m_OwnerTelephone;
        private eCarState m_CarState;
        private eFuelType m_FuelType;
        public VehicleCard(Vehicle i_Vehicle, string i_CarOwner, string i_OwnerTelephone, eCarState i_CarState, eFuelType i_FuelType)
        {
            this.m_Vehicle = i_Vehicle;
            this.m_CarOwner = i_CarOwner;
            this.m_OwnerTelephone = i_OwnerTelephone;
            this.m_CarState = i_CarState;
            this.m_FuelType = i_FuelType;
        }

        public override string ToString()
        {
            string d = string.Format("Car Owner: {0}\nTelephone: {1}\nVehicle status: {2}", m_CarOwner, m_OwnerTelephone, m_CarState.ToString());
            string s = m_Vehicle.ToString() + "\n" + d + "\n" + m_Vehicle.PrintTiers(); 
            return s;
        }

        public static string generateValidVehicleState()
        {
            string validCarState = string.Empty;
            while (true)
            {
                validCarState = Console.ReadLine();
                try
                {
                    if (!validCarState.ToLower().Equals("fixing") && !validCarState.ToLower().Equals("fixed") && !validCarState.ToLower().Equals("paid"))
                    {
                        throw new ArgumentException();
                    }
                    return validCarState;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("ONLY VALID STATES FIXING/FIXED/PAID");
                    Console.WriteLine(e.Message);
                }
            }
        }

        public eEngineType GetEngineType()
        {
            return this.m_Vehicle.getEngineType();
        }

        public Vehicle getVehicle()
        {
            return this.m_Vehicle;
        }

        public eCarState GetCarState()
        {
            return m_CarState;
        }

        public void setCarState(eCarState i_CarState)
        {
            this.m_CarState = i_CarState;
        }

        public eFuelType GetFuelType()
        {
            return m_FuelType;
        }
    }

    public enum eCarType
    {
        Car,
        Truck,
        Morotcycle
    }

    public enum eCarState
    {
        Fixing,
        Fixed,
        Paid
    }
}

