using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.AbstractFactory
{
    public class SqlserverUser : IUser
    {
        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(User user)
        {
            Console.WriteLine("sqlserver新增user");
        }
    }
}
