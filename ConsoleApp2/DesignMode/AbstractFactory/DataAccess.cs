using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp2.DesignMode.AbstractFactory
{
    public class DataAccess
    {
        private static readonly string db = "sqlserver";

        public static IUser CreateUser()
        {
            IUser user = null;
            switch (db)
            {
                case "sqlserver":
                    user = new SqlserverUser();
                    break;
                case "access":
                    break;
            }
            return user;
        }
    }

    public class DataAccessReflection
    {

        private static readonly string AssemblyName = "ConsoleApp2";
        private static readonly string db = "Sqlserver";

        private static IUser _IUser = null;
        public static IUser IUser
        {
            get
            {

                if (_IUser == null)
                {
                    string className = AssemblyName +".DesignMode.AbstractFactory."+ db + "User";
                    _IUser = (IUser)Assembly.Load(AssemblyName).CreateInstance(className);
                }
                return _IUser;
            }
        }


    }
}
