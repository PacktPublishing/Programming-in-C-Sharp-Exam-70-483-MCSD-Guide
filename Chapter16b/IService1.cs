using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Chapter16b
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Student RetrieveStudentData();
    }

    [DataContract]
    public class Student
    {
        [DataMember]
        public string FirstName;
        [DataMember]
        public string LastName;
        [DataMember]
        public int ID;

        public Student(string v1, string v2, int v3)
        {
            this.FirstName = v1;
            this.LastName = v2;
            this.ID = v3;
        }                
    }
}
