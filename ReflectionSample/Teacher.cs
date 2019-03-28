using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionSample
{
    public class Teacher
    {
        private static Teacher _instance = null;
        private Teacher()
        {

        }
        public static Teacher GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Teacher();
            }
            return _instance;
        }
        public string Name { get; set; }
        public string Course { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }

        public void Introduce()
        {
            Console.WriteLine($"大家好，我是一个{Course}教师，大家可以叫我{Name}");
        }

        private void Hobby()
        {
            Console.WriteLine("我是一个喜欢画画的老师");
        }
        public void Work()
        {
            Console.WriteLine($"我是教师，我正在上课！");
        }

        public void Work(string course)
        {
            Console.WriteLine($"我是教师，我正在教{course}课！");
        }
        public void Work(string course,int num)
        {
            Console.WriteLine($"我是教师，我正在教{course}课，今天已经上了{num}节课了！");
        }
    }
}
