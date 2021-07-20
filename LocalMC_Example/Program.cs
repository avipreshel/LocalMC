using System;
using System.Text;
using System.Threading;
using LocalMQ;

namespace LocalMQ_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(() =>
           {
               using OutPipe outPipe = new OutPipe("the_pipe");
               outPipe.Write(Encoding.Default.GetBytes("Hello"));
               Console.ReadKey();
           }).Start();

            new Thread(() =>
            {
                using InPipe inPipe = new InPipe("the_pipe", (msg)=>
                {
                    Console.WriteLine(Encoding.Default.GetString(msg));
                    
                });
                Console.ReadKey();

            }).Start();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
