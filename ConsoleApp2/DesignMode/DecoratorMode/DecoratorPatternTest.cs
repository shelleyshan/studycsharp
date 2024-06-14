using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.DecoratorMode
{
    public class DecoratorPatternTest
    {
        public static void Test()
        {
            Circle circle = new Circle();
            circle.Draw();

            RedShapeDecorator redShapeDecorator = new RedShapeDecorator(new Circle());
            redShapeDecorator.Draw();

            BlueShapeDecorator blueShapeDecorator = new BlueShapeDecorator(new Circle());
            blueShapeDecorator.Draw();
        }
    }
}
