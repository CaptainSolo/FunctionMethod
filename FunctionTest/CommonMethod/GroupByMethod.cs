using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module;
using Newtonsoft.Json;

namespace CommonMethod
{
    public class GroupByMethod
    {
        public static void LingBroupBy()
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee()
            {
                ID = 1,
                FName = "John",
                Age = 23,
                Sex = 'M'
            });
            empList.Add(new Employee()
            {
                ID = 2,
                FName = "Mary",
                Age = 23,
                Sex = 'M'
            });

            empList.Add(new Employee()
            {
                ID = 3,
                FName = "Amber",
                Age = 23,
                Sex = 'M'
            });
            empList.Add(new Employee()
            {
                ID = 4,
                FName = "Kathy",
                Age = 25,
                Sex = 'M'
            });
            empList.Add(new Employee()
            {
                ID = 5,
                FName = "Lena",
                Age = 25,
                Sex = 'F'
            });

            empList.Add(new Employee()
            {
                ID = 6,
                FName = "Bill",
                Age = 28,
                Sex = 'M'
            });

            empList.Add(new Employee()
            {
                ID = 7,
                FName = "Celina",
                Age = 27,
                Sex = 'F'
            });
            empList.Add(new Employee()
            {
                ID = 8,
                FName = "John",
                Age = 28,
                Sex = 'M'
            });

            var sums = empList
                         .GroupBy(x => x.Sex)
                         .Select(group => new
                         {
                             List = group.GroupBy(m => m.Age).Select(p => new { name = p.First().FName, age = p.Key, Sex = group.Key }).ToList()
                         })
                         .ToList();
            sums.ForEach(item =>
            {
                item.List.ForEach(p =>
                {
                    Console.WriteLine(p.Sex + ": " + p.age + ";" + p.name);
                });
            });
        }
    }


    [Description("员工")]
    public class Employee
    {
        //[JsonProperty(propertyName: "AAA")]
        public int ID { get; set; }
        [Description("姓名")]
        public string FName { get; set; }
        [Description("年龄")]
        public int Age { get; set; }
        [Description("性别")]
        public char Sex { get; set; }
        [Description("子女")]
        public List<Student> Chilld { get; set; }
    }
}
