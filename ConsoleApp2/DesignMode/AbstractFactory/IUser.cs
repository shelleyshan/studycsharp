using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.AbstractFactory
{
    public interface IUser
    {
        User GetUser(int id);

        void Insert(User user);
    }
}
