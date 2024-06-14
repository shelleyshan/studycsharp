using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.CommandMode
{
    public class Barbecuer
    {
        public void BakeMutton()
        {
            Console.WriteLine("烤羊肉串");
        }

        public void BakeChickenWing() {
            Console.WriteLine("烤鸡翅");
        }
    }



}
