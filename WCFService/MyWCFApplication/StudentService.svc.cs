using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWCFApplication
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class StudentService : IStudentService
    {
        public List<Student> GetStudentByClass(string className)
        {
            //实际开发中在这个地方根据班级名称查询学员列表，此处省略

            return new List<Student>
            {
                 new Student { StudentId=1001,StudentName="WCF学员1",ClassName=".NET-VIP（1）班"},
                 new Student { StudentId=1002,StudentName="WCF学员2",ClassName=".NET-VIP（1）班"},
                 new Student { StudentId=1003,StudentName="WCF学员3",ClassName=".NET-VIP（1）班"},
                 new Student { StudentId=1004,StudentName="WCF学员4",ClassName=".NET-VIP（1）班"},
                 new Student { StudentId=1005,StudentName="WCF学员5",ClassName=".NET-VIP（1）班"},
                 new Student { StudentId=1006,StudentName="WCF学员6",ClassName=".NET-VIP（1）班"}
            };
        }
    }
}
