using StudySummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    /// <summary>
    ///1：语法糖  编译成占位符方式   编译器会帮期完成
    ///2：延迟加载 方法声明的时候没有指定参数类型  在方法使用的时候 才去指定参数类型
    ///3： 编译时的动态解析 运行时的动态解析
    ///4：让一个方法 支持不同的参数
    ///解决缺陷：方法定义太多 减少装箱拆箱
    /// </summary>
    public class GenericMethod
    {
        /// 延迟声明：把参数类型的声明推迟到调用
        /// 不是语法糖，而是由框架升级提供的功能
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter) where T : Parent
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(GenericMethod), tParameter.GetType().Name, tParameter.ToString());
        }
    }
}
