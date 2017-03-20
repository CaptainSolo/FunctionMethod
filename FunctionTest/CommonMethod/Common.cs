using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Module;
using Newtonsoft.Json;

namespace CommonMethod
{
    public class Common
    {
        /// <summary>
        /// 验证数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool CheckDigit(string value)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(value);
        }

        public static string RemoveNumber(string key)
        {
            return Regex.Replace(key, @"\d", "");
        }

        public static void BatAddStudent()
        {
            Student a = new Student()
            {
                ID = 1,
                Name = "A",
                Age = 8,
                Type = 1
            };
            Student b = new Student()
            {
                ID = 2,
                Name = "B",
                Age = 9,
                Type = 1
            };
            Student c = new Student()
            {
                ID = 3,
                Name = "C",
                Age = 10,
                Type = 1
            };
            Student d = new Student()
            {
                ID = 4,
                Name = "D",
                Age = 11,
                Type = 1
            };
            Student e = new Student()
            {
                ID = 5,
                Name = "E",
                Age = 12,
                Type = 1
            };
            Student f = null;
            List<Student> stu1 = new List<Student>();
            List<Student> stu2 = new List<Student>();

            stu1.Add(a);
            stu1.Add(b);
            stu1.Add(c);

            stu2.Add(a);
            stu2.Add(d);
            stu2.Add(e);
            stu2.Add(f);

            List<Student> ss = new List<Student>();
            ss.AddRange(stu2);
            ss.AddRange(stu1);

            Console.WriteLine(ss.ToJson());
            Console.Read();
        }

        public static void CheckFirstOrDefault()
        {
            List<Student> list = new List<Student>();
            var listC = list.Find(p => p.ID > 5);
            var listA = list.FirstOrDefault();

            var listB = list.First();
        }


        public static Dictionary<long, string> GetResourceDayInfo(List<string> list)
        {
            List<string> resourceValue = list.Where(p => !string.IsNullOrEmpty(p) && p != "0").ToList();
            Dictionary<long, string> resourceDay = new Dictionary<long, string>();
            resourceValue.ForEach(item =>
            {
                var resourceUseValue = item.Split('_');
                if (resourceUseValue.Length.Equals(2))
                {
                    if (!string.IsNullOrEmpty(resourceUseValue[0]) && !string.IsNullOrEmpty(resourceUseValue[1]))
                    {
                        long resourceId = resourceUseValue[0].ToLong();
                        int useDay = resourceUseValue[1].ToInt32();
                        if (resourceDay.ContainsKey(resourceId))
                        {
                            resourceDay[resourceId] = resourceDay[resourceId] + "," + useDay;
                        }
                        else
                        {
                            resourceDay.Add(resourceId, useDay.ToString());
                        }
                    }
                }
            });
            return resourceDay;
        }

        /// Json自定义别名
        /// <summary>
        /// Json自定义别名
        /// </summary>
        /// <returns></returns>
        public static string ConvertJsonMethod()
        {
            Employee ee = new Employee();
            ee.Age = 16;
            ee.FName = "张三";
            ee.ID = 20;
            ee.Sex = '1';
            string a = JsonConvert.SerializeObject(ee);
            return a;
        }

        public static void TestFirst()
        {

            //var temp1 = employees.First();         //直接报错,编译不通过

            //employees.Add(new Employee());
            //var temp3 = employees.First();
            //var temp4 = employees.FirstOrDefault();

            List<Employee> employees = new List<Employee>();
            if (employees != null && employees.Any())
            {
                var temp2 = employees.FirstOrDefault();  //null
            }
            else
            {

            }

        }

        public static void GetDesc()
        {

            var a = (ProductOperateEnum)1;
            string str = a.ToString();
            FieldInfo field2 = a.GetType().GetField(str);
            var temp2 = (DescriptionAttribute)Attribute.GetCustomAttribute(field2, typeof(DescriptionAttribute));
        }


        /// APP端URL拼接
        /// <summary>
        /// APP端URL拼接
        /// </summary>
        /// <param name="lineProperty"></param>
        /// <param name="lineProType"></param>
        /// <param name="lineId"></param>
        /// <returns></returns>
        public static string GetAppUrl(int lineProperty, int lineProType, long lineId)
        {
            StringBuilder sbStr = new StringBuilder();
            string url = "https://m.17u.cn/app/pje/144343233?sUrl=m.ly.com";
            string url1 = "|guoneiyou|line|";
            string url2 = ".html";
            string url3 = "https:||m.ly.com|guoneiyou|line|";
            string url4 = ".html?refid=158839879";
            string urlDync = string.Format("t{0}j{1}p{2}c{3}", lineProperty, lineProType, lineId, 0);
            var sUrl = string.Format("|guoneiyou|line|t{0}j{1}p{2}c{3}.html", lineProperty, lineProType, lineId, 0);
            var rUrl = string.Format("https:||m.ly.com|guoneiyou|line|t{0}j{1}p{2}c{3}.html?refid=158839879", lineProperty, lineProType, lineId, 0);
            sbStr.Append(string.Format("{0}{1}&rUrl={2}", url, UrlEncode(sUrl), UrlEncode(rUrl)));
            string aa = sbStr.ToString();
            sbStr=new StringBuilder();
            sbStr.Append(string.Format("{0}{1}{2}{3}&rUrl={4}{2}{5}", url, UrlEncode(url1), UrlEncode(urlDync), UrlEncode(url2), UrlEncode(url3), UrlEncode(url4)));
            sbStr = new StringBuilder();
            sbStr.Append(url);
            sbStr.Append(UrlEncode(url1));
            sbStr.Append("{0}");
            sbStr.Append(UrlEncode(url2));
            sbStr.Append("&rUrl=");
            sbStr.Append(UrlEncode(url3));
            sbStr.Append("{0}");
            sbStr.Append(UrlEncode(url4));
            string bb=string.Format(sbStr.ToString(),UrlEncode(urlDync));

            sbStr = new StringBuilder();
            sbStr.Append("https://m.17u.cn/app/pje/144343233?sUrl=m.ly.com");
            sbStr.Append(UrlEncode("|guoneiyou|line|"));
            sbStr.Append("{0}");
            sbStr.Append(string.Format("{0}&rUrl={1}", UrlEncode(".html"), UrlEncode("https:||m.ly.com|guoneiyou|line|")));
            sbStr.Append("{0}");
            sbStr.Append(UrlEncode(".html?refid=158839879"));
            string cc = string.Format(sbStr.ToString(), UrlEncode(urlDync));

            return sbStr.ToString();

        }

        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str);
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }

        /// 耗时监控
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string TimeWatch()
        {
            StringBuilder sbtime = new StringBuilder();
            Stopwatch watch = new Stopwatch();
            watch.Start();

            watch.Stop();
            sbtime.Append(string.Format("X{0}.耗时：{1}\n", 0, watch.ElapsedMilliseconds));
            watch.Reset();
            watch.Start();

            watch.Stop();
            sbtime.Append(string.Format("X{0}.耗时：{1}\n", 1, watch.ElapsedMilliseconds));
            watch.Reset();
            watch.Start();

            watch.Stop();
            sbtime.Append(string.Format("P.耗时：{0}\n", watch.Elapsed.Milliseconds / 1000));

            return sbtime.ToString();
        }

    }
}
