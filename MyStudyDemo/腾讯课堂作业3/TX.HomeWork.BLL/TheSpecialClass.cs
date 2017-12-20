using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TX.HomeWork.BLL
{
    public class TheSpecialClass
    {
        public static T ThreadPoolWithCallBackExt<T>(Func<object, T> fuc, Action callBackAction, string name)
        {
             ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            T tValue = default(T);
            WaitCallback newWaitCallback = t =>
            {
                tValue = fuc(t);
                manualResetEvent.Set();
                callBackAction.Invoke();
            };
            ThreadPool.QueueUserWorkItem(newWaitCallback, name);
            manualResetEvent.WaitOne();
            return tValue;
        }

        public static void ThreadContinueWhenAny(List<Action> actionList, Action callBackAction)
        {
            List<Thread> list = new List<Thread>();
            ThreadStart threadStart = null;
            actionList.ForEach(item =>
            {
                threadStart = () => item.Invoke();
                Thread thread = new Thread(threadStart);
                thread.Start();
                list.Add(thread);
            });
            //重新开启一个线程 不会影响 主线程
            Thread callBackThread = new Thread(() =>
            {
                while (list.Any(a => a.ThreadState == ThreadState.Stopped))
                {
                    callBackAction.Invoke();
                    break;
                }
            });
            callBackThread.Start();
        }

        public static void ThreadContinueWhenAll(List<Action> actionList, Action callBackAction)
        {
            List<Thread> list = new List<Thread>();
            ThreadStart threadStart = null;
            actionList.ForEach(item =>
            {
                threadStart = () => item.Invoke();
                Thread thread = new Thread(threadStart);
                thread.Start();
                list.Add(thread);
            });
            //重新开启一个线程 不会影响 主线程
            Thread callBackThread = new Thread(() =>
            {
                while (list.Count(a => a.ThreadState == ThreadState.Stopped) == list.Count())
                {
                    callBackAction.Invoke();
                    break;
                }
            });
            callBackThread.Start();
        }

        public static void ThreadPoolContinueWhenAny(List<Action> actionList, Action callBackAction)
        {
            List<ManualResetEvent> list = new List<ManualResetEvent>();
            actionList.ForEach(item =>
            {
                ManualResetEvent manualResetEvent = new ManualResetEvent(false);
                list.Add(manualResetEvent);
                ThreadPool.QueueUserWorkItem(t => { item.Invoke(); manualResetEvent.Set(); });
            });

            ThreadPool.QueueUserWorkItem(t =>
            {
                WaitHandle.WaitAny(list.ToArray());
                callBackAction();
            });
        }

        public static void ThreadPoolContinueWhenAll(List<Action> actionList, Action callBackAction)
        {
            List<ManualResetEvent> list = new List<ManualResetEvent>();
            actionList.ForEach(item =>
            {
                ManualResetEvent manualResetEvent = new ManualResetEvent(false);
                list.Add(manualResetEvent);
                ThreadPool.QueueUserWorkItem(t => { item.Invoke(); manualResetEvent.Set(); });
            });

            ThreadPool.QueueUserWorkItem(t =>
            {
                WaitHandle.WaitAll(list.ToArray());
                callBackAction();
            });
        }
    }
}
