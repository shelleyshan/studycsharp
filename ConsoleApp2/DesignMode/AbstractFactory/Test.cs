using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.AbstractFactory
{
    public class Test1
    {
        public static void TestAbstractFactory()
        {
            //  IFactory factory = new SqlServerFactory();
            //  IUser user = factory.CreateUser();
            //  user.GetUser(1);
            //  ICompany company = factory.CreateCompany();
            //  company.GetCompany(1);

            //var iuser =  DataAccess.CreateUser();

            DataAccessReflection.IUser.Insert(null);
            DataAccessReflection.IUser.Insert(null);
        }
    }
}
