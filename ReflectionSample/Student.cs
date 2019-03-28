using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionSample
{
    public class Student
    {
        public Student()
        {

        }
        public Student(string name)
        {
            this.Name = name;
        }
        public Student(string name,int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public int Id { get; set; }
        public string Name { get ; set; }
        public string Province { get; set; }
        public bool Gender { get ; set ; }
        public int Age { get ; set; }

        public void Introduce()
        {
            Console.WriteLine($"大家好，我是一个学生，名字是{Name},来自{Province}");
        }

        public void Work()
        {
            Console.WriteLine($"我是学生，我正在认真写作业！");
        }
    }
}
