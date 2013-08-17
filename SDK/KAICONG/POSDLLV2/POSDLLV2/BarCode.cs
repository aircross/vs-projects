using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel; 
using System.Drawing; 
using System.Data;
using System.Collections;

namespace POSDLL
{
    //生成条码
    class BarCode
    {

        /// <summary>
        /// QRCode
        /// </summary>
        public class QRCode
        {

        }

        /// <summary> 
        /// 生成条码Code39 
        /// </summary> 
        public class Code39
        {
            private Hashtable m_Code39 = new Hashtable();

            private byte m_Magnify = 0;
            /// <summary> 
            /// 放大倍数 
            /// </summary> 
            public byte Magnify { get { return m_Magnify; } set { m_Magnify = value; } }

            private int m_Height = 40;
            /// <summary> 
            /// 图形高 
            /// </summary> 
            public int Height { get { return m_Height; } set { m_Height = value; } }

            public Code39()
            {

                m_Code39.Add("A", "1101010010110");
                m_Code39.Add("B", "1011010010110");
                m_Code39.Add("C", "1101101001010");
                m_Code39.Add("D", "1010110010110");
                m_Code39.Add("E", "1101011001010");
                m_Code39.Add("F", "1011011001010");
                m_Code39.Add("G", "1010100110110");
                m_Code39.Add("H", "1101010011010");
                m_Code39.Add("I", "1011010011010");
                m_Code39.Add("J", "1010110011010");
                m_Code39.Add("K", "1101010100110");
                m_Code39.Add("L", "1011010100110");
                m_Code39.Add("M", "1101101010010");
                m_Code39.Add("N", "1010110100110");
                m_Code39.Add("O", "1101011010010");
                m_Code39.Add("P", "1011011010010");
                m_Code39.Add("Q", "1010101100110");
                m_Code39.Add("R", "1101010110010");
                m_Code39.Add("S", "1011010110010");
                m_Code39.Add("T", "1010110110010");
                m_Code39.Add("U", "1100101010110");
                m_Code39.Add("V", "1001101010110");
                m_Code39.Add("W", "1100110101010");
                m_Code39.Add("X", "1001011010110");
                m_Code39.Add("Y", "1100101101010");
                m_Code39.Add("Z", "1001101101010");
                m_Code39.Add("0", "1010011011010");
                m_Code39.Add("1", "1101001010110");
                m_Code39.Add("2", "1011001010110");
                m_Code39.Add("3", "1101100101010");
                m_Code39.Add("4", "1010011010110");
                m_Code39.Add("5", "1101001101010");
                m_Code39.Add("6", "1011001101010");
                m_Code39.Add("7", "1010010110110");
                m_Code39.Add("8", "1101001011010");
                m_Code39.Add("9", "1011001011010");
                m_Code39.Add("+", "1001010010010");
                m_Code39.Add("-", "1001010110110");
                m_Code39.Add("*", "1001011011010");
                m_Code39.Add("/", "1001001010010");
                m_Code39.Add("%", "1010010010010");
                //m_Code39.Add("contentquot;, "1001001001010"); 
                m_Code39.Add(".", "1100101011010");
                m_Code39.Add(" ", "1001101011010");

            }
        }
    }
}
