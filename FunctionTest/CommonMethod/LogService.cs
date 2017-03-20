using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Module;

namespace CommonMethod
{
    public class LogService
    {
        public static void CompareStudent()
        {
            Student s1 = new Student();
            s1.ID = 1;
            s1.Name = "张飞";
            s1.Age = 16;
            s1.Type = 1;

            Student s2 = new Student();
            s2.ID = 1;
            s2.Name = "赵云";
            s2.Age = 16;
            s2.Type = 1;

            List<Student> students1 = new List<Student>();
            List<Student> students2 = new List<Student>();
            students1.Add(s1);
            students2.Add(s2);

            //GetDescprition(students);

            List<Employee> empList = new List<Employee>();
            Employee employee1 = new Employee()
            {
                ID = 1,
                FName = "John",
                Age = 23,
                Sex = 'F',
                Chilld = students1
            };

            empList.Add(new Employee()
            {
                ID = 1,
                FName = "John",
                Age = 23,
                Sex = 'F',
                Chilld = students2
            });

            empList.Add(new Employee()
            {
                ID = 2,
                FName = "Mary",
                Age = 24,
                Sex = 'F',
                Chilld = students1
            });

            empList.Add(new Employee()
            {
                ID = 3,
                FName = "Amber",
                Age = 26,
                Sex = 'M'
            });

            GetOperateLogInfoByAppend(employee1);
        }

        static string GetOperateLogInfoByAppend<T>(T t)
        {
            StringBuilder msg = new StringBuilder();
            string titleName = string.Empty;
            string descriptionName = string.Empty;

            Type temp = t.GetType();
            var pros = temp.GetProperties();

            titleName = GetAttributeName(temp);//备注为空则不参与比较
            for (int i = 0; i < pros.Length; i++)
            {
                var t1 = pros[i].GetValue(t, null);

                if (t1 != null)
                {
                    descriptionName = GetAttributeName(pros[i]);//备注为空则不参与比较
                    if (!string.IsNullOrEmpty(descriptionName))
                    {
                        var tempFullName = pros[i].PropertyType.FullName;
                        if (tempFullName.Contains("List`1"))//集合
                        {
                            msg.Append("");
                            //Type type = Type.GetType(tempFullName);
                            //object obj = type.Assembly.CreateInstance(type); 
                        }
                        else if (tempFullName.Contains("Module"))//对象
                        {
                            //将obj转化成具体对象
                            var tempx = (Activator.CreateInstance(t1.GetType(), t1));
                            msg.Append(GetOperateLogInfoByAppend(tempx));
                        }
                        else
                        {
                            msg.Append(string.Format("{0}:{1};\n", descriptionName, t1));
                        }
                    }
                }
            }
            msg.Insert(0, string.Format("{0}:\n", titleName));

            return msg.ToString();
        }

        static string GetOperateLogInfoByEdit<T>(List<T> t)
        {
            StringBuilder msg = new StringBuilder();
            string titleName = string.Empty;
            string descriptionName = string.Empty;
            var temp1 = t[0];
            var temp2 = t[1];
            Type temp = temp1.GetType();
            var pros = temp.GetProperties();

            if (temp1.ToJson() != temp2.ToJson())
            {
                titleName = GetAttributeName(temp);//备注为空则不参与比较
                for (int i = 0; i < pros.Length; i++)
                {
                    var t1 = pros[i].GetValue(temp1, null);
                    var t2 = pros[i].GetValue(temp2, null);

                    if (!t1.Equals(t2))
                    {
                        descriptionName = GetAttributeName(pros[i]);//备注为空则不参与比较
                        if (!string.IsNullOrEmpty(descriptionName))
                        {
                            var tempFullName = pros[i].PropertyType.FullName;
                            if (tempFullName.Contains("List`1"))//集合
                            {
                                msg.Append("");
                                //Type type = Type.GetType(tempFullName);
                                //object obj = type.Assembly.CreateInstance(type); 
                            }
                            else if (tempFullName.Contains("Module"))//对象
                            {
                                //将obj转化成具体对象
                                var tempx = (Activator.CreateInstance(t1.GetType(), t1));
                                var tempy = (Activator.CreateInstance(t1.GetType(), t2));
                                msg.Append(GetOperateLogInfoByEdit(GetChildList(tempx, tempy)));
                            }
                            else
                            {
                                msg.Append(string.Format("{0}:{1}->{2};\n", descriptionName, t1, t2));
                            }
                        }
                    }
                }
                msg.Insert(0, string.Format("{0}:\n", titleName));
            }

            return msg.ToString();
        }

        public static List<T> GetChildList<T>(T t1, T t2)
        {
            List<T> tempList = new List<T>();
            tempList.Add(t1);
            tempList.Add(t2);
            return tempList;
        }

        /// 获取属性备注
        /// <summary>
        /// 获取属性备注
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        static string GetAttributeName(MemberInfo info)
        {
            string name = string.Empty;
            if (info != null)
            {
                var descObj = (DescriptionAttribute)Attribute.GetCustomAttribute(info, typeof(DescriptionAttribute));
                if (descObj != null)
                    name = (descObj).Description;// 属性值
            }
            return name;
        }
    }
}
