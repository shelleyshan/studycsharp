using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.AbstractFactory
{
    public interface IFactory
    {
        IUser CreateUser();
        ICompany CreateCompany();
    }
}
