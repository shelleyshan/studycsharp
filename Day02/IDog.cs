using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    public interface IDog
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Shout();
    }
}
