using System;
using System.ComponentModel;

namespace Module
{
    [Description("学生")]
    public class Student
    {
        public Student()
        {

        }
        private Student _obj;
        public Student(object obj)
        {
            _obj = (Student)obj;
            if (_obj != null)
            {
                ID = _obj.ID;
                Name = _obj.Name;
                Age = _obj.Age;
                Type = _obj.Type;
            }
        }
        public int ID { get; set; }
        [Description("姓名")]
        public string Name { get; set; }
        [Description("年龄")]
        public int Age { get; set; }
        [Description("类型")]
        public int Type { get; set; }
    }
}
