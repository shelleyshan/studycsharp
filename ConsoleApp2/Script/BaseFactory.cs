using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Script
{
    public class BaseFactory
    {
     
        public static BaseCaculate GetCalculateObject(string function)
        {
            BaseCaculate baseCaculate = null;
            switch (function)
            {
                case "+":
                    baseCaculate = new AddCalculate();

                    break;
                case "-":
                    baseCaculate = new SubtractionCalculate();
                    break;
                default:
                    baseCaculate = new AddCalculate();

                    break;
            }
            return baseCaculate;
        }

        
    
    }
}
