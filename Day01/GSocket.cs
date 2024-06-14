using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    public class GSocket:IDisposable
    {
        public SocketHandle socketHandle;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class SocketHandle
    {
        public GSocket GameSocket;
    }
}
