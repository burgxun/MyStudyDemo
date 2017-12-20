using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TX.HomeWork.Common;
using TX.HomeWork.Model;
using System.Threading;
using System.Diagnostics;

namespace TX.HomeWork.BLL
{
    public class DothingMethod
    {
        private static object FirstThingLock = new object();
        private static object AllThingLock = new object();
        private static bool IsHasFirstComplate = false;
        private static bool IsHasAllComplate = false;

        public static void DoSomething()
        {
            CancellationTokenSource startCancelTokenSource = new CancellationTokenSource();
            CancellationTokenSource endCancelTokenSource = new CancellationTokenSource();

            try
            {
                Task.Run(() =>
                {
                    while (!endCancelTokenSource.IsCancellationRequested)
                    {
                        Thread.Sleep(400);
                        if (new Random().Next(0, 1000) == DateTime.Now.Year)
                        {
                            Print("天降雷霆灭世，天龙八部的故事就此结束....", 9);
                            startCancelTokenSource.Cancel();
                            endCancelTokenSource.Cancel();
                        }
                    }
                });

                Stopwatch watch = new Stopwatch();
                watch.Start();
                Print(String.Format("***********************天龙八部的故事Start 主线程id {0}**********************************", Thread.CurrentThread.ManagedThreadId), 1);
                List<Task> taskList = new List<Task>();
                TaskFactory taskFactory = new TaskFactory();
                List<ConfigThingModel> list = JsonHelper.getConfigThing();
                foreach (var item in list)
                {
                    Task task = taskFactory.StartNew(() =>
                    {
                        if (startCancelTokenSource.IsCancellationRequested)
                            return;

                        string name = item.Name;
                        List<string> dotingList = item.Dothing;
                        dotingList.ForEach(a =>
                        {
                            if (startCancelTokenSource.IsCancellationRequested)
                                return;

                            if (!IsHasFirstComplate)
                            {
                                lock (FirstThingLock)
                                {
                                    Print(name + ":" + a);
                                    if (!IsHasFirstComplate)
                                    {
                                        IsHasFirstComplate = true;
                                        Print("天龙八部就此拉开序幕。。。。", 12);
                                    }
                                }
                            }
                            else
                            {
                                Print(name + ":" + a, 14);
                            }

                        });

                        if (!IsHasAllComplate)
                        {
                            lock (AllThingLock)
                            {
                                if (!IsHasAllComplate)
                                {
                                    IsHasAllComplate = true;
                                    Print(name + "已经做好准备啦。。。。", 14);
                                }
                            };
                        }

                    });
                    taskList.Add(task);
                }
                Task.WaitAll(taskList.ToArray());
                if (!startCancelTokenSource.IsCancellationRequested)
                {
                    Print("中原群雄大战辽兵，忠义两难一死谢天", 12);
                }
                else
                {
                    endCancelTokenSource.Cancel();
                }
                Print(String.Format("***********************天龙八部的故事End 主线程id {0}**********************************", Thread.CurrentThread.ManagedThreadId), 1);
                watch.Stop();
                Print("故事一共花费了:" + watch.ElapsedMilliseconds + "秒", 1);
            }
            catch (Exception ex)
            {
                Print(ex.Message);
            }
            finally
            {
                endCancelTokenSource.Cancel();
            }

        }

        private static void Print(string str, int colorValue = 0)
        {
            Random random = new Random();
            Thread.Sleep(random.Next(600, 1000));
            Console.ForegroundColor = (ConsoleColor)colorValue;
            Console.WriteLine(str);
            LogHelper.WriteLog(str);
        }
    }
}
