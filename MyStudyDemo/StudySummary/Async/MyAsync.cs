using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndThread
{
    public class MyAsync
    {
        public void ShowSomething()
        {
            Action action = () =>
            {
                Console.WriteLine("测试");
                Console.WriteLine("这里是执行的函数 {0}", Thread.CurrentThread.ManagedThreadId);
            };

            AsyncCallback asyncCallback = t =>
            {
                Console.WriteLine(t.AsyncState);//StateParameter
                Console.WriteLine("这里是回调函数 {0}", Thread.CurrentThread.ManagedThreadId);
            };

            // action.Invoke();
            IAsyncResult asyncResult = action.BeginInvoke(asyncCallback, "StateParameter");

            while (!asyncResult.IsCompleted)
            {
                Console.WriteLine("任务还在执行当中。。。");
            }
            asyncResult.AsyncWaitHandle.WaitOne();//阻止当前主线程 等待异步执行完成
            asyncResult.AsyncWaitHandle.WaitOne(-1);//永远等待
            asyncResult.AsyncWaitHandle.WaitOne(10000);//等待10000秒后 停止等待

            Func<int, string> func = t => { return t.ToString(); };
            asyncResult = func.BeginInvoke(123, asyncCallback, "StateParameterFunc");

            string result = func.EndInvoke(asyncResult);//获取异步方法执行的结果
        }
    }
}
