using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyWCFService.MyWCFServiceClient client = new MyWCFService.MyWCFServiceClient();
            string myTask = client.GetMyTask("0001");

            Console.WriteLine("我今天的任务：" + myTask);
            Console.Read();
        }
    }
}
