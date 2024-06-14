using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.AbstractFactory
{
    public interface ICompany
    {
        Company GetCompany(int id);

        void Insert(Company user);
    }
}
