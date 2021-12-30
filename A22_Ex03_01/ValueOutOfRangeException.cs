using System;

namespace A22_Ex03_01
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        public  ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
           : base(string.Format(" out of range of {0} - {1} ", i_MaxValue, i_MinValue))
        {
        }
        public ValueOutOfRangeException(float i_Value)
            : base(string.Format("out of range {0} - {1} ", 0, i_Value))
        {

        }

        public float MaxValue { 
            get
            {
                return m_MaxValue;
            } 
            set
            { 
                m_MaxValue =value;
            }
        }
        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
            set
            {
                m_MinValue = value;
            }
        }
    }
}
