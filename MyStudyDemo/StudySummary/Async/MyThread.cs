using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndThread
{
    public class MyThread
    {
        public static void ShowThread()
        {
            ThreadStart threadStart = () => Console.WriteLine("这是一个线程");
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

        public static void ShowThreadPool()
        {
            ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            WaitCallback waitCallback = t =>
            {
                Console.WriteLine("这是一个线程池方法，参数:" + t);
                manualResetEvent.Set();
            };
            ThreadPool.QueueUserWorkItem(waitCallback, "parameterState");
            manualResetEvent.WaitOne();//线程等待

        }

        public static void ShowTask()
        {
            List<Task> listTask = new List<Task>();
            TaskFactory taskFactory = new TaskFactory();
            Task task = taskFactory.StartNew(() => Console.WriteLine("这是一个taskFactory线程"));
            listTask.Add(task);

            Task task2 = new Task(() => Console.WriteLine("这是一个task 线程"));
            task2.Start();
            listTask.Add(task2);

            Task task3 = Task.Run(() => Console.WriteLine("这是一个task run 线程"));
            listTask.Add(task3);

            Task.WaitAll(listTask.ToArray());
            Task.WaitAny(listTask.ToArray());

            taskFactory.ContinueWhenAll(listTask.ToArray(), t => { Console.WriteLine("这个是回调函数"); });
            taskFactory.ContinueWhenAny(listTask.ToArray(), t => { Console.WriteLine("这个是回调函数"); });
        }

        public static void ShowParallel()
        {
            Parallel.For(1, 10, new ParallelOptions() { MaxDegreeOfParallelism = 5 }, (i, state) =>
            {
                Console.WriteLine("当前{0},{1},{2}", i, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
            });

            string[] data = { "str1", "str2", "str3" };
            ParallelLoopResult result = Parallel.ForEach<string>(data, str =>
            {
                Console.WriteLine(str);
            });
            Console.WriteLine("是否完成:{0}", result.IsCompleted);
            Console.WriteLine("最低迭代:{0}", result.LowestBreakIteration);

            Parallel.Invoke(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine("method1");
            }, () =>
            {
                Thread.Sleep(10);
                Console.WriteLine("method2");
            });
        }
    }
}
