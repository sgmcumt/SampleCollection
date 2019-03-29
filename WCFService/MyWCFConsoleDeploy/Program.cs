using MyWCFLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyWCFConsoleDeploy
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用ServiceHost启动
            ServiceHost host = new ServiceHost(typeof(StudentService));
            host.Open();
            Console.WriteLine("WCF Service is Started!");
            Console.Read();
        }
    }
}
