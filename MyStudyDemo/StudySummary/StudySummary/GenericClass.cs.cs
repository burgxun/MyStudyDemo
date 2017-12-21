using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySummary
{
    /// <summary>
    /// 泛型类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericClass<T>
    {
        public void Show(T t)
        {
            Console.WriteLine(t);
        }

        public void GenericMethod<W, X, Y, Z, Yoyo, Eleven>()
        { }

        public T Get(T t)
        {
            List<int> iList = null;
            return t;
        }
    }

    /// <summary>
    /// 泛型接口 
    /// </summary>
    /// <typeparam name="T">定义内部使用的参数T类型的</typeparam>
    public interface IGet<T>
    {
        void Print(T model);
    }

    /// <summary>
    /// 泛型委托
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public delegate void GetHandler<T>();

    /// <summary>
    /// 类继承 泛型类  泛型接口
    /// </summary>
    public class ChildClass : GenericClass<int>, IGet<string>
    {
        public void Print(string model)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 泛型类继承 泛型类  泛型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="W"></typeparam>
    public class ChildClass<T, W> : GenericClass<T>, IGet<W>
    {
        private Child child = new Child();

        public void Print(W model)
        {
            throw new NotImplementedException();
        }
    }


    public class Parent
    {
        public Parent(string name)
        { }
    }

    public class Child : Parent
    {
        public Child() : base("123")
        { }
    }
}
