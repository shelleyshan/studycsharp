using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.AbstractFactory
{
    public class SqlserverCompany : ICompany
    {

       public Company GetCompany(int id)
        {
          
            throw new NotImplementedException();
        }

       public void Insert(Company user)
        {
            throw new NotImplementedException();
        }
    }
}
