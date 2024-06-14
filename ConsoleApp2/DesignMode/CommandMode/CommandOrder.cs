using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.CommandMode
{
    public abstract class CommandOrder
    {
        protected Barbecuer baseBarbecuer;

        public CommandOrder(Barbecuer baseBarbecuer)
        {
            this.baseBarbecuer = baseBarbecuer;
        }

        public abstract void Execute();
    }

    public class BakerMuttonOrder : CommandOrder
    {
        public BakerMuttonOrder(Barbecuer baseBarbecuer) : base(baseBarbecuer)
        {
        }

        public override void Execute()
        {
            baseBarbecuer.BakeMutton();
        }
    }

    public class BakeChickenWingOrder : CommandOrder
    {
        public BakeChickenWingOrder(Barbecuer baseBarbecuer) : base(baseBarbecuer)
        {
        }

        public override void Execute()
        {
            baseBarbecuer.BakeChickenWing();
        }
    }


    public class Waiter
    {
        IList<CommandOrder> orderList = new List<CommandOrder>();

        public void CommandAdd(CommandOrder commandOrder)
        {
            orderList.Add(commandOrder);

        }

        public void CommandExecute()
        {
            foreach (CommandOrder commandOrder in orderList)
            {
                commandOrder.Execute();

            }
        }

        public void CommandRemove()
        {

        }
    }

    public class Test
    {
        public void Test1()
        {
            Barbecuer boy = new Barbecuer();

            CommandOrder commandOrder1 = new BakerMuttonOrder(boy);
            CommandOrder commandOrder2 = new BakeChickenWingOrder(boy);
            Waiter girl = new Waiter();
            girl.CommandAdd(commandOrder2);
            girl.CommandAdd(commandOrder1);
            girl.CommandExecute();
        }

    }
}
