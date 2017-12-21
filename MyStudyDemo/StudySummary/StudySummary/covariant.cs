using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySummary
{
    /// <summary>
    /// 只能放在接口或者委托的泛型参数前面
    /// out 协变covariant       修饰返回值
    /// in  逆变contravariant   修饰传入参数
    public class covariant
    {
        /// <summary>
        /// *    可变性只能用于   引用类型
        /// **   C# 4.0 引入的
        /// ***  只能放在接口或者委托的泛型参数前面  
        /// **** 对于泛型类型参数来说，如果要将该类型的实参传给使用 out 或者 ref 关键字的方法，便不允许可变性，如： delegate void someDelegate<in T>(ref T t)   这段代码编译器会报错。
        /// 
        /// out 协变covariant    修饰返回值      如果某个返回的类型可以由其派生类型替换，那么这个类型就是支持协变的    IEnumerable<T>
        /// in  逆变contravariant  修饰传入参数  如果某个参数类型可以由其基类替换，那么这个类型就是支持逆变的。     Action<T>
        /// </summary>
        public static void TestShowDemo()
        {
            {
                Parent parent = new Parent("name");
                Parent parentNew = new Child();//子类 可以赋值到父类中
            }
            {
                List<Parent> listP = new List<Parent>();
                //  List<Parent> listPNew = new List<Child>();//两个list泛型实例不存在继承关系
                List<Parent> listPNew = new List<Child>().Select(a => (Parent)a).ToList();
            }
            {
                IEnumerable<Parent> parent = new List<Parent>();
                IEnumerable<Parent> parentIE = new List<Child>();//out 协变  是修饰返回参数的

                Action<Parent> actionChild = (item) => Console.WriteLine("逆变");
                Action<Child> actionParent = actionChild;//in  逆变contravariant  修饰传入参数
            }
            {
                IDoSomeThingOut<Parent> doSomeThingOut = new DoSomeThingOut<Child>();// out 协变  是修饰返回参数的  作为返回参数的时候  子类可以替代父类

                IDoSomeThingIn<Child> doSomeThingIn = new DoSomeThingIn<Parent>();//in  逆变contravariant  修饰传入参数
                IDoSomeThingIn<Parent> doInParent = new DoSomeThingIn<Parent>();
                doInParent.Show(new Child());
                doInParent.Show(new Parent("Name"));


            }
        }
    }

    public interface IDoSomeThingIn<in T>
    {
        void Show(T parameter);
    }

    public class DoSomeThingIn<T> : IDoSomeThingIn<T>
    {
        public void Show(T parameter)
        {
            throw new NotImplementedException();
        }
    }

    public interface IDoSomeThingOut<out T>
    {
        T GetT();
    }

    public class DoSomeThingOut<T> : IDoSomeThingOut<T>
    {
        T IDoSomeThingOut<T>.GetT()
        {
            throw new NotImplementedException();
        }
    }
}
