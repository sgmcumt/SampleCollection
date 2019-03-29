using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWCFApplication
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        List<Student> GetStudentByClass(string className);
    }


    [DataContract]
    public class Student
    {
        [DataMember]
        public int StudentId { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string ClassName { get; set; }

    }
}
