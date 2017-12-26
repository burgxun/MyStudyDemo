using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndThread
{
    public class ThreadSpecial
    {
        /// <summary>
        /// ThreadPool 去支持回调的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="callBackAction"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static T ThreadPoolWithCallBackExt<T>(Func<string, T> func, Action callBackAction, string parameter)
        {
            ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            T tValue = default(T);

            WaitCallback waitCallback = t =>
            {
                tValue = func(t.ToString());
                callBackAction();
                manualResetEvent.Set();
            };
            ThreadPool.QueueUserWorkItem(waitCallback, parameter);
            manualResetEvent.WaitOne();
            return tValue;
        }

        public static void ThreadContinueWhenAny(List<Action> listAction, Action callBackAction)
        {
            List<Thread> listThread = new List<Thread>();
            ThreadStart threadStart;
            listAction.ForEach(item =>
            {
                threadStart = () => item.Invoke();
                Thread thread = new Thread(threadStart);
                listThread.Add(thread);
                thread.Start();
            });
            //重新开一个线程 相当于守护线程
            Thread threadBack = new Thread(() =>
            {
                while (listThread.Any(a => a.ThreadState == ThreadState.Stopped))
                {
                    callBackAction();
                    break;
                }
            });
        }

        public static void ThreadContinueWhenAll(List<Action> listAction, Action callBackAction)
        {
            List<Thread> listThread = new List<Thread>();
            listAction.ForEach(item =>
            {
                Thread thread = new Thread(() => item.Invoke());
                listThread.Add(thread);
                thread.Start();
            });
            Thread threadBack = new Thread(() =>
            {
                while (listThread.Count(a => a.ThreadState == ThreadState.Stopped) == listThread.Count())
                {
                    callBackAction();
                    break;
                }
            });
        }


        public static void ThreadPoolContinueWhenAny(List<Action> listAction, Action callBackAction)
        {
            List<ManualResetEvent> listMRE = new List<ManualResetEvent>();
            listAction.ForEach(item =>
            {
                ThreadPool.QueueUserWorkItem(t =>
                {
                    ManualResetEvent manualResetEvent = new ManualResetEvent(false);
                    item.Invoke();
                    manualResetEvent.Set();
                    listMRE.Add(manualResetEvent);
                });
            });
            ThreadPool.QueueUserWorkItem(t =>
            {
                WaitHandle.WaitAny(listMRE.ToArray());
                callBackAction.Invoke();
            }, "State");
        }

        public static void ThreadPoolContinueWhenAll(List<Action> listAction, Action callBackAction)
        {
            List<ManualResetEvent> listMRE = new List<ManualResetEvent>();
            listAction.ForEach(item =>
            {
                ThreadPool.QueueUserWorkItem(t =>
                {
                    ManualResetEvent manualResetEvent = new ManualResetEvent(false);
                    item.Invoke();
                    manualResetEvent.Set();
                    listMRE.Add(manualResetEvent);
                });
            });
            ThreadPool.QueueUserWorkItem(t =>
            {
                WaitHandle.WaitAll(listMRE.ToArray());
                callBackAction.Invoke();
            }, "State");
        }
    }
}
