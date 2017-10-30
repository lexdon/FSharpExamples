using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServiceLibraryExample
{
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string SayHelloWorld();

        [OperationContract]
        string SayHelloTo(string name);

        [OperationContract]
        Greeting GetGreetingFor(string name);

        [OperationContract]
        string FormatGreeting(Greeting greeting);
    }

    [DataContract]
    public class Greeting
    {
        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public DateTime TimeStamp { get; set; }
    }
}
