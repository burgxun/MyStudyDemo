using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public sealed class Singleton
    {
        private Singleton()
        {
            Console.WriteLine("初始化一次");//私有的构造函数
        }

        /// <summary>
        /// 由CLR保证，在程序第一次使用该类之前被调用，而且只调用一次
        /// </summary>
        private static Singleton singleton = new Singleton();

        public static Singleton GetSingleton()
        {
            return singleton;
        }
    }
    /// <summary>
    /// 单例模式2 
    /// </summary>
    public class SingletonSecond
    {
        private SingletonSecond()
        {
            //私有构造函数 逻辑   只能内部调用 外部没法调用
        }

        private static SingletonSecond _SingletonSecond = null;

        /// <summary>
        /// 静态构造函数  程序第一次使用的时候  被调用
        /// </summary>
        static SingletonSecond()
        {
            _SingletonSecond = new SingletonSecond();
        }

        public static SingletonSecond GetSingleton()
        {
            return _SingletonSecond;
        }
    }
    /// <summary>
    ///  单例模式3
    /// </summary>
    public class SingletonThird
    {
        private SingletonThird()
        {
            //私有构造函数 逻辑   只能内部调用 外部没法调用
        }
        private static object _SingletonLock = new object();
        private static SingletonThird _SingletonThird = null;

        /// <summary>
        /// if lock if 保证多线程安全
        /// </summary>
        /// <returns></returns>
        public static SingletonThird GetSingletonThird()
        {
            if (_SingletonThird == null)
            {
                lock (_SingletonThird)
                {
                    if (_SingletonThird == null)
                    {
                        _SingletonThird = new SingletonThird();
                    }
                }
            }
            return _SingletonThird;
        }
    }
}
