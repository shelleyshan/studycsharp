using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.DecoratorMode
{
    public class RedShapeDecorator : ShapeDecorator
    {

        public RedShapeDecorator(IShape decoratedShape) : base(decoratedShape)
        {
        }

        public new void Draw()
        {
            decoratedShape.Draw();
            SetRedBorder(decoratedShape);
        }

        private void SetRedBorder(IShape shape)
        {
            Console.WriteLine("Border Color: Red");
        }

    }
}
