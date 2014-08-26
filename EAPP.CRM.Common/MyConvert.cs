using System;
using System.Collections.Generic;
using System.Text;

namespace EAPP.CRM.Common
{
    public class MyConvert
    {
        /// <summary>
        /// 转换返回Int32类型
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static Int32 GetInt32(string num)
        {
            int number = 0;

            int.TryParse(num, out number);

            return number;
        }

        /// <summary>
        /// 转换返回Int16类型
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static Int16 GetInt16(string num)
        {
            Int16 number = 0;

            Int16.TryParse(num, out number);

            return number;
        }

        /// <summary>
        /// 转换返回Int64类型
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static Int64 GetInt64(string num)
        {
            Int64 number = 0;

            Int64.TryParse(num, out number);

            return number;
        }

        /// <summary>
        /// 转换返回Boolean类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Boolean GetBoolean(string value)
        {
            Boolean _value = false;

            Boolean.TryParse(value, out _value);

            return _value;
        }

        /// <summary>
        /// 转换返回Double类型
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static Double GetDouble(string num)
        {
            Double value = 0;

            Double.TryParse(num, out value);

            return value;
        }

        /// <summary>
        /// 转换返回Decimal类型
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static Decimal GetDecimal(string num)
        {
            Decimal value = 0;

            Decimal.TryParse(num, out value);

            return value;
        }

        /// <summary>
        /// 转换返回float类型
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static float GetFloat(string num)
        {
            float value = 0;

            float.TryParse(num, out value);

            return value;
        }

        /// <summary>
        /// 转换返回DateTime类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(string value)
        {
            DateTime _value =  DateTime.Now;

            DateTime.TryParse(value, out _value);

            return _value;
        }
    }
}
