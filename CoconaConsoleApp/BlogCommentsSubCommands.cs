using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoconaConsoleApp
{
    public class BlogCommentsSubCommands
    {
        public ValueTask<int> Search()
        {
            Console.WriteLine("11111");
            return ValueTask.FromResult(0);
        }
        public void Moderate()
        {
            Console.WriteLine("2222");
        }
    }
}
