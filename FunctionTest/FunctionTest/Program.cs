using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CommonMethod;
using Module;

namespace FunctionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Common.CheckFirstOrDefault();
            //string str = "上海+苏州+杭州+南京+无锡双飞6日跟团游";
            //str = str.Substring(str.Length - 4);

            //EntityMethod.GetComplaintInfo();

            //List<string> list=new List<string>();
            //list.Add("365_1");
            //list.Add("365_2");
            //list.Add("0");
            //list.Add("360_4");
            //list.Add("360_");
            //list.Add("365_5");
            //list.Add("0");
            //Common.GetResourceDayInfo(list);

            //GroupByMethod.LingBroupBy();


            //Common.TestFirst();
            //string a = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //string b = DateTime.Now.ToString("M");
            //Common.GetAppUrl(1, 4, 109683);
            //LogService.CompareStudent();

            //string a = null;
            //string b = string.Format("{0}", a);

            //decimal a = 0.6578M;
            //int b = Convert.ToInt32(a*100);

            string a = "123,222";
            Regex rule = new Regex(@"^[\d|\,|，]+(\,\，\d+)*$");
            bool check = rule.IsMatch(a);

            Console.Read();
        }
    }

}
