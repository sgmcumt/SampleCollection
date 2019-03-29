using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyNetMSMQService
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用ServiceHost启动
            ServiceHost host = new ServiceHost(typeof(MyWCFService));
            host.Open();
            Console.WriteLine("WCF服务已启动！！！！！！！");
            Console.ReadLine();
        }
    }
}
