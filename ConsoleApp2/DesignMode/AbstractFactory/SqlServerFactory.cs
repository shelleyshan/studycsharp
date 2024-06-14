using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.AbstractFactory
{
    public class SqlServerFactory : IFactory, IDisposable
    {
        public ICompany CreateCompany()
        {
            return new SqlserverCompany();
        }

        public IUser CreateUser()
        {
            return new SqlserverUser();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
