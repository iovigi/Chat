using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BLs.Services
{
    public interface IChatSession
    {
        IAsyncEnumerable<string> Chat(string text);
    }
}
