using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyNetTcpService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“MyWCFService”。
    public class MyWCFService : IMyWCFService
    {
        public string GetMyTask(string jobId)
        {
            return "今天加班把设计方案做出来";
        }
    }
}
