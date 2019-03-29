using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AsyncWCFService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“MyWCFService”。
    public class MyWCFService : IMyWCFService
    {
        public string GetCourseName(int courseId)
        {
            System.Threading.Thread.Sleep(3000);

            return "这个是异步调用返回的数据：WCF通信技术";
        }
    }
}
