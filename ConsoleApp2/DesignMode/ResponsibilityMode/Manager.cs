using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.ResponsibilityMode
{
    class Request
    {
        private string requsetType;

        public string RequestContent { get => requestContent; set => requestContent = value; }

        private string requestContent;
        public int RequestCount { get => requestCount; set => requestCount = value; }

        private int requestCount;

    }
    abstract class Manager
    {
        protected string name;
        protected Manager superior;
        public Manager(string name)
        {
            this.name = name;
        }

        public void SetSuperior(Manager superior)
        {
            this.superior = superior;
        }

        abstract public void RequestApplications(int request);
    }

    class CommonManager : Manager
    {
        public CommonManager(string name) : base(name)
        {
        }

        public override void RequestApplications(int request)
        {
            if (request < 10)
            {
                Console.WriteLine($"{this.GetType().Name}处理请求{request}");
            }
            else
            {
                superior?.RequestApplications(request);
            }
        }
    }

    class Majordomo : Manager
    {
        public Majordomo(string name) : base(name)
        {
        }

        public override void RequestApplications(int request)
        {
            if (request < 20)
            {
                Console.WriteLine($"{this.GetType().Name}处理请求{request}");
            }
            else
            {
                superior?.RequestApplications(request);
            }
        }
    }

    public class TestResponsibility : BaseSingleton<TestResponsibility>
    {

        public override void Test()
        {
            CommonManager commonManager = new CommonManager("部门经理");
            Majordomo majordomo = new Majordomo("总经理");
            commonManager.SetSuperior(majordomo);
            commonManager.RequestApplications(1);
            commonManager.RequestApplications(12);
        }

        public static T clone<T>(T obj)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }
    }


}
