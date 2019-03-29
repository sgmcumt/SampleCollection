using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWCFClient
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    MyWCFService.MyWCFServiceClient client = new MyWCFService.MyWCFServiceClient();

        //    Console.WriteLine(DateTime.Now.ToLongTimeString() + "    【主线程】正在调用耗时的WCF服务...");

        //    string courseName = client.GetCourseName(1001);

        //    Console.WriteLine(DateTime.Now.ToLongTimeString() + "    " + courseName);
        //    Console.WriteLine("【主线程】执行完毕！");
        //    Console.Read();
        //}
        ////【1】异步方法1：调用生成的异步方法
        //static void Main(string[] args)
        //{
        //    MyWCFService.MyWCFServiceClient client = new MyWCFService.MyWCFServiceClient();

        //    Console.WriteLine("开始异步调用：" + DateTime.Now.ToLongTimeString() + "\r\n");

        //    //开始异步调用
        //    client.BeginGetCourseName(100, (obj) =>
        //     {
        //         var myClient = (MyWCFService.MyWCFServiceClient)obj.AsyncState;
        //         string courseName = myClient.EndGetCourseName(obj);
        //         Console.WriteLine("\r\n异步调用结束：" + DateTime.Now.ToLongTimeString() + "   " + courseName);
        //     }, client);

        //    Console.WriteLine("【主线程】执行完毕！");
        //    Console.Read();
        //}


        ////【2】异步方法2：基于事件的异步调用
        //static void Main(string[] args)
        //{
        //    MyWCFService.MyWCFServiceClient client = new MyWCFService.MyWCFServiceClient();

        //    Console.WriteLine("开始异步调用：" + DateTime.Now.ToLongTimeString() + "\r\n");

        //    //异步调用方法的执行
        //    client.GetCourseNameAsync(1001);

        //    //调用结束后执行的事件
        //    client.GetCourseNameCompleted += (obj, e) =>
        //     {
        //         Console.WriteLine("\r\n异步调用结束：" + DateTime.Now.ToLongTimeString() + "   " + e.Result);
        //     };

        //    Console.WriteLine("【主线程】执行完毕！");
        //    Console.Read();
        //}

        //【3】异步方法3：基于多线程
        static void Main(string[] args)
        {
            MyWCFService.MyWCFServiceClient client = new MyWCFService.MyWCFServiceClient();

            Console.WriteLine("开始异步调用：" + DateTime.Now.ToLongTimeString() + "\r\n");

            //异步调用方法的执行
            //client.GetCourseNameAsync(1001);

            //使用Task工厂开启多线程
            Task.Factory.StartNew(() =>
            {
                string courseName = client.GetCourseName(1001);
                Console.WriteLine("\r\n异步调用结束：" + DateTime.Now.ToLongTimeString() + "   " + courseName);
            });

            Console.WriteLine("【主线程】执行完毕！");
            Console.Read();
        }
    }
}
