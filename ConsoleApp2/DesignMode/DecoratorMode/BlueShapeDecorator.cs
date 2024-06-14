using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.DecoratorMode
{
    public class BlueShapeDecorator : ShapeDecorator
    {
        public BlueShapeDecorator(IShape decoratedShape) : base(decoratedShape)
        {
        }

        public new void Draw()
        {
            base.Draw();
            setBlueBorder(decoratedShape);
        }

        private void setBlueBorder(IShape shape)
        {
            Console.WriteLine("Border Color:Blue");
        }
    }
}
