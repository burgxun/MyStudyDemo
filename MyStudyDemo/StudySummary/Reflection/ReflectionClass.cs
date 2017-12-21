using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    /// <summary>
    /// 1 dll-IL-metadata-反射
    /// 2 反射加载dll，读取module、类、方法、特性
    /// 3 反射创建对象，反射+简单工厂+配置文件  选修：破坏单例 创建泛型
    /// 4 反射调用实例方法、静态方法、重载方法 选修:调用私有方法 调用泛型方法
    /// 5 反射字段和属性，分别获取值和设置值
    /// 6 反射的好处和局限
    /// </summary>
    public class ReflectionClass
    {

        public void ReflectionMethod()
        {
            Assembly assembly = Assembly.Load("Reflection");//DLL Name 动态加载DLL

            Type type = assembly.GetType("Reflection.ReflectionTest");//Class Name 类名称时全名称
            #region 反射加载dll 去读取类的 字段 属性 方法 特性 构招函数 
            foreach (var item in type.GetConstructors())
            {
                Console.WriteLine(item.Name);
            }
            foreach (var item in type.GetProperties())
            {
                Console.WriteLine(item.Name);
            }
            foreach (var item in type.GetMethods())
            {
                Console.WriteLine(item.Name);
            }
            foreach (var item in type.GetFields())
            {
                Console.WriteLine(item.Name);
            }
            foreach (var item in type.GetCustomAttributes())
            {

            }
            #endregion

            #region 反射创建对象，反射+简单工厂+配置文件  选修：破坏单例 创建泛型
            var instance = Activator.CreateInstance(type);//去创建一个实类对象  ReflectionTest()
            Activator.CreateInstance(type, "demon");//带参数的  ReflectionTest(string name)
            Activator.CreateInstance(type, 11, "限量版(397-限量版)");// 带参数的   ReflectionTest(int id, string name)

            //破坏单例
            Type typeSingleton = assembly.GetType("Reflection.Singleton");
            var singleInstance = Activator.CreateInstance(typeSingleton, true);

            //泛型类
            Type typeGeneric = assembly.GetType("Ruanmou.DB.Sqlserver.GenericClass`1");
            typeGeneric = typeGeneric.MakeGenericType(typeof(int));
            var genericInstance = Activator.CreateInstance(typeGeneric);
            #endregion`

            #region 反射调用实例方法、静态方法、重载方法 选修:调用私有方法 调用泛型方法
            MethodInfo method1 = type.GetMethod("Show1");
            method1.Invoke(instance, null);//Show1()  实例方法

            MethodInfo method2 = type.GetMethod("Show2");
            method2.Invoke(instance, new object[] { 11 });//Show2(int id) 实例方法

            MethodInfo methodStatic = type.GetMethod("ShowStatic");
            methodStatic.Invoke(null, new object[] { "Name" }); // ShowStatic(string name)  静态方法

            // 重载 方法
            {
                MethodInfo method = type.GetMethod("Show3", new Type[] { });//Show3 方法重载参数
                method.Invoke(instance, null);
            }
            {
                MethodInfo method = type.GetMethod("Show3", new Type[] { typeof(int) });
                method.Invoke(instance, new object[] { 11 });
            }
            {
                MethodInfo method = type.GetMethod("Show3", new Type[] { typeof(string), typeof(int) });
                method.Invoke(instance, new object[] { "书呆熊@拜仁", 22 });
            }

            {
                MethodInfo method = type.GetMethod("Show4", BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(instance, new object[] { "有木有" });
            }
            {
                MethodInfo method = type.GetMethod("ShowGeneric");
                method = method.MakeGenericMethod(typeof(string));
                method.Invoke(instance, new object[] { "有木有" });
            }
            #endregion
        }
    }
}
