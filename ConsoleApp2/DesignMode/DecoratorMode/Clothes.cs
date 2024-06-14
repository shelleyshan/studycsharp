using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.DecorateMode
{
    public class Clothes
    {
        public void GirlClothes()
        {
            Console.WriteLine("女孩衣服");
        }

        public void BoyClothes()
        {
            Console.WriteLine("男孩衣服");
        }
    }

    public class Trouser
    {
        public void GirlTorouser()
        {
            Console.WriteLine("女孩裤子");
        }

        public void BoyTorouser()
        {
            Console.WriteLine("男孩裤子");
        }
    }

    public class Wear
    {
        Clothes clothes = new Clothes();
        Trouser trouser = new Trouser();
        public void Girl()
        { 
            
            clothes.GirlClothes();
           
            trouser.GirlTorouser();
        
        }
    }
}
