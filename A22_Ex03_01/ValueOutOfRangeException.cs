using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A22_Ex03_01
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public  ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
            Console.WriteLine(format:" ", i_MinValue, i_MaxValue);// need to check with exception
        }
        public ValueOutOfRangeException(float i_Value)
        {
            m_MinValue = 0;
            Console.WriteLine(format: "",m_MinValue,i_Value);
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
