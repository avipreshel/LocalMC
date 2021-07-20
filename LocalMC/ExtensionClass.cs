using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMQ
{
    public static class ExtensionClass
    {
        public static void DumpTrace(this string str)
        {
            Console.WriteLine(str);
        }
    }
}
