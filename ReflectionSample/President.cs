using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionSample
{
    public class President
    {
        public string schoolSpirit = "好好学习";
        public President()
        {

        }
        
        public string Name { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public string School { get; set; }
        private void Secret()
        {
            Console.WriteLine("这是一个神秘的事情");
        }
        public static void Work(string task)
        {
            Console.WriteLine($"我今天要研究的内容是{task}");
        }
        public void AdvancedWork<T1,T2>(T1 task,T2 time)
        {
            Console.WriteLine($"我今天临时安排做{task},预计花费{time}小时");
        }
        public void Teach()
        {
            Console.WriteLine("我的职责是让学生安心学习");
        }
        /// <summary>
        /// 自我介绍
        /// </summary>
        public void Introduce()
        {
            Console.WriteLine($"大家好，我是一名校长");
        }
        public void Introduce(string schoolName)
        {
            Console.WriteLine($"大家好，我是{schoolName}的校长");
        }
        public void Introduce(string schoolName,int classCount)
        {
            Console.WriteLine($"大家好，我是{schoolName}的校长，我们学校共有{classCount}班级");
        }
        public void Test()
        {

        }
    }
}
