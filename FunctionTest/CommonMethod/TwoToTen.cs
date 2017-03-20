using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMethod
{
    //二进制与十进制转换
    public class TwoToTen
    {
        /// 转化为十进制
        /// <summary>
        /// 转化为十进制
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int ConvertToTen(string value)
        {
            return Convert.ToInt32(value, 2);
        }

        /// 转化为二进制
        /// <summary>
        /// 转化为二进制
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ConvertToTwo(int value)
        {
            return Convert.ToString(value, 2);
        }

        public void Function2To10()
        {
            int a = Convert.ToInt32("11001", 2);
            string b = Convert.ToString(a, 2);
            List<int> list = ResolveValue(a);
            Console.WriteLine(string.Join(",", list.ToArray()));
            Console.Read();
        }

        /// 获取选中的位置
        /// <summary>
        /// 获取选中的位置
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<int> ResolveValue(int value)
        {
            string newValue = Convert.ToString(value, 2);
            char[] arr = newValue.ToCharArray();
            Array.Reverse(arr);
            List<int> list = new List<int>();
            int index = 0;
            foreach (char item in arr)
            {
                if (item == '1')
                    list.Add(index);
                index++;
            }
            return list;
        }
    }
}
