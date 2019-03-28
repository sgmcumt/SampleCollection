using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionSample
{
    /// <summary>
    /// 辅导员
    /// </summary>
    /// <typeparam name="T">泛型类</typeparam>
    public class Counsellor<T1>
    {
        public void Introduce(T1 t1)
        {
            Console.WriteLine($"GenericCounsellor<T1 >： public void Introduce(T1 t1) 方法被调用！");
            Console.WriteLine($"T1的类型={t1.GetType().Name}");
        }
    }
    /// <summary>
    /// 辅导员泛型类：2个泛型参数
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class Counsellor<T1, T2>
    {
        public void Introduce(T1 t1, T2 t2)
        {
            Console.WriteLine($"GenericCounsellor<T1, T2>： public void Introduce(T1 t1,T2 t2) 方法被调用！");
            Console.WriteLine($"T1的类型={t1.GetType().Name}  T2的类型={t2.GetType().Name} ");
            Console.WriteLine($"大家好！我是{t1}{t2}");
        }
    }
}
