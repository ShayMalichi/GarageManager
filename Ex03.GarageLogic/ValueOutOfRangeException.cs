using System;
namespace GarageManager
{
    public class ValueOutOfRangeException : Exception
    {
        float MaxValue;
        float MinValue;
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) :
            base(string.Format("please only enter values between {0} - {1}", i_MinValue, i_MaxValue))
        {
            this.MinValue = i_MinValue;
            this.MaxValue = i_MaxValue;

        }
    }
}




