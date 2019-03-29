using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWCFLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class StudentService : IStudentService
    {
        public List<Student> GetStudentByClass(string className)
        {
            //实际开发中，我们应该在这个地方根据班级名称查询学员对象信息...
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
