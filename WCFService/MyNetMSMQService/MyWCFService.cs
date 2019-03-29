using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyNetMSMQService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“MyWCFService”。
    public class MyWCFService : IMyWCFService
    {
        public void GetClientInfo(string content)
        {
            Console.WriteLine($"接收到消息:{content}, 时间：{DateTime.Now.ToLongTimeString()}");
        }

    }
}
