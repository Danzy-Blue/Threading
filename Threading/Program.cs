using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    public class Program
    {
        int counter = 1000;

        static void Main(string[] args)
        {

            Program p = new Program();
            Thread t1 = new Thread(MethodWithoutParameter);          // Kick off a new thread
            t1.Name = "t1";
            t1.Start();                               // running WriteY()

            Thread t2 = new Thread(() =>
            {
                p.MethodWithParameter("X ");
            });
            t2.Name = "t2";
            t2.Start();

            Thread t3 = new Thread(() =>
            {
                p.MethodWithParameter("Y ");
            });
            t3.Name = "t3";
            t3.Start();

            Thread.CurrentThread.Name = "M";
            p.MethodWithParameter("Z ");


            // Simultaneously, do something on the main thread.
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(Thread.CurrentThread.Name + ":x ");
            }

        }

        static void MethodWithoutParameter()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(Thread.CurrentThread.Name + ":Y ");
            }
        }
        public void MethodWithParameter(string str)
        {


            for (int i = 0; i < counter; i++)
            {
                Console.Write(Thread.CurrentThread.Name + ":" + i + ":" + str);
            }
        }
    }
}
