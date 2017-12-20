using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TX.HomeWork.BLL;

namespace 腾讯课堂作业3
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    DothingMethod.DoSomething();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            CancellationTokenSource cts1 = new CancellationTokenSource();
            cts1.Token.Register(() => { Console.WriteLine("Register cts1 Action1"); });

            CancellationTokenSource cts2 = new CancellationTokenSource();
            cts2.Token.Register(() => { Console.WriteLine("Register cts1 Action2"); });

            CancellationTokenSource cts3 = CancellationTokenSource.CreateLinkedTokenSource(cts2.Token, cts1.Token);
            CancellationToken ct = cts3.Token;
            CancellationTokenRegistration ctr2 = ct.Register(DoAction);

            cts1.Cancel();

            Console.WriteLine("cts1:{0},cts2:{1},cts3:{2}", cts1.IsCancellationRequested, cts2.IsCancellationRequested, cts3.IsCancellationRequested);
           
        }

        public static void DoAction()
        {
            Console.WriteLine("Register cts1 Action3");
        }
    }
}
