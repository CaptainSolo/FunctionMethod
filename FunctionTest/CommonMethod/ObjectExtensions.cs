using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CommonMethod
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// 对象深拷贝
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T DeepClone<T>(this T source)
        {
            if (source == null)
                return default(T);
            string jsonString = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        /// <summary>
        /// 根据字符串转换为时间类型集合
        /// </summary>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <returns></returns>

        public static List<DateTime> ToDateList(this string source, params char[] separator)
        {
            if (string.IsNullOrWhiteSpace(source))
                return new List<DateTime>();
            return source.Split(separator).Select(item => item.ToDate()).ToList();
        }

        /// <summary>
        /// 字符串转换为日期
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime ToDate(this string source)
        {
            DateTime resut = DateTime.MinValue;
            if (string.IsNullOrWhiteSpace(source))
                return resut;
            DateTime.TryParse(source, out resut);
            return resut;
        }

        /// <summary>
        /// 字符串转换为日期
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns></returns>
        public static DateTime ToDateByDefault(this string source)
        {
            DateTime result = new DateTime(1900, 1, 1);
            if (string.IsNullOrWhiteSpace(source)) return result;
            DateTime.TryParse(source, out result);
            return result;
        }

        /// <summary>
        /// 从对象转换为Json字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToJson(this object source)
        {
            if (source == null)
                return string.Empty;
            return JsonConvert.SerializeObject(source);
        }

        /// <summary>
        /// 从Json字符串转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T ToObject<T>(this string source)
        {
            if (string.IsNullOrWhiteSpace(source) || source.JsonEmpty())
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(source);
        }

        /// <summary>
        /// Json字符串是否为空或null
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool JsonEmpty(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return true;
            if (string.Equals("[]", source, StringComparison.OrdinalIgnoreCase))
                return true;
            if (string.Equals("null", source, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }


        /// <summary>
        /// 转换为Int32类型
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defvalue"></param>
        /// <returns></returns>
        public static int ToInt32(this object source, int defvalue = 0)
        {
            int result = 0;
            if (null == source)
                return defvalue;
            if (int.TryParse(source.ToString(), out result))
            {
                return result;
            }
            else
            {
                return defvalue;
            }
        }

        /// <summary>
        /// 转换为long类型
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defvalue"></param>
        /// <returns></returns>
        public static long ToLong(this object source, int defvalue = 0)
        {
            long result = 0;
            if (null == source)
                return defvalue;
            if (long.TryParse(source.ToString(), out result))
            {
                return result;
            }
            else
            {
                return defvalue;
            }
        }

        /// <summary>
        /// 转化为decimal型
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defvalue"></param>
        /// <returns></returns>
        public static decimal ObjectToDecimal(this object source, decimal defvalue = 0)
        {
            decimal result = 0;
            if (null == source)
                return defvalue;
            if (decimal.TryParse(source.ToString(), out result))
            {
                return result;
            }
            else
            {
                return defvalue;
            }

        }
    }
}
