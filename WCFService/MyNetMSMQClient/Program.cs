using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetMSMQClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyWCFService.MyWCFServiceClient client = new MyWCFService.MyWCFServiceClient();
            Console.WriteLine("ClientApp启动");
            System.Threading.Thread.Sleep(3000);
            client.GetClientInfo("王小二");
            Console.WriteLine("ClientApp发送第1次消息！");
            System.Threading.Thread.Sleep(2000);
            client.GetClientInfo("李晓红");
            Console.WriteLine("ClientApp发送第2次消息！");
            System.Threading.Thread.Sleep(1000);
            client.GetClientInfo("流泪了");
            Console.WriteLine("ClientApp发送第3次消息！");

            Console.WriteLine("消息发送完毕！");
            Console.Read();
        }
    }
}
