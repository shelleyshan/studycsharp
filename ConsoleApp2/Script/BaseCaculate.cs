using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Script
{
    public abstract class BaseCaculate
    {

        public abstract int GetCalculate(int firstParam, int secondParam);
    }

    public class AddCalculate : BaseCaculate
    {
        public override int GetCalculate(int firstParam, int secondParam)
        {
            return firstParam + secondParam;
        }
    }

    public class SubtractionCalculate : BaseCaculate
    {
        public override int GetCalculate(int firstParam, int secondParam)
        {
            return firstParam - secondParam;
        }
    }


    public class Context
    {
        private BaseCaculate baseCaculate;

        public Context(string operation)
        {
            switch (operation)
            {
                case "+":
                    this.baseCaculate = new AddCalculate();
                    break;
                case "-":
                    this.baseCaculate = new SubtractionCalculate();
                    break;
                default:
                    this.baseCaculate = new AddCalculate();
                    break;
            }
           
        }

        public int GetOperation(int first, int second)
        {
            return this.baseCaculate.GetCalculate(first, second);
        }
    }


}
