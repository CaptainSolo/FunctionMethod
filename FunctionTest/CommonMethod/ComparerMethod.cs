using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module;

namespace CommonMethod
{
    public class ComparerMethod
    {
        public void CompareStudent()
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

            List<Student> stu1 = new List<Student>();
            List<Student> stu2 = new List<Student>();

            stu1.Add(a);
            stu1.Add(b);
            stu1.Add(c);

            stu2.Add(a);
            stu2.Add(d);
            stu2.Add(e);

            var sA = stu1.Except(stu2,new ComparerStudentFunction()).ToList();
            sA.ForEach(p =>
            {
                Console.WriteLine("A比B多" + p.Name);
            });
            var sB = stu2.Intersect(stu1).ToList();
            sB.ForEach(p =>
            {
                Console.WriteLine("A与B的交集" + p.Name);
            });
            Console.Read();
        }
    }

    /// 比较规则
    /// <summary>
    /// 比较规则
    /// </summary>
    public class ComparerFunction : IEqualityComparer<string>
    {
        public bool Equals(string str1, string str2)
        {
            return str1 == str2;
        }
        public int GetHashCode(string str)
        {
            return str.GetHashCode();
        }
    }

    /// 比较规则
    /// <summary>
    /// 比较规则
    /// </summary>
    public class ComparerStudentFunction : IEqualityComparer<Student>
    {
        public bool Equals(Student stu1, Student stu2)
        {
            return stu1.ID == stu2.ID;
        }
        public int GetHashCode(Student stu)
        {
            return stu.ToString().GetHashCode();
        }
    }
}
