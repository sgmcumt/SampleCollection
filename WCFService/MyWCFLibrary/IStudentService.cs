using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWCFLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        List<Student> GetStudentByClass(string className);

        //实际开发中，大家可以在这个地方继续添加其他的接口...

    }
    /// <summary>
    /// 学员实体类
    /// </summary>
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
