using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TX.Homework.Factory;
using TX.Homework.Interface;

namespace 腾讯课堂作业5
{
    class Program
    {
        private static string BestDishName = string.Empty;
        private static double BestDishPoint = 0;
        private static object _BestLock = new object();

        static void Main(string[] args)
        {
            //初始化 生成菜单
            //TaskFactory taskFactory = new TaskFactory();
            //List<Task> taskList = new List<Task>();
            //CustomerAction("甲");

            //taskList.Add(taskFactory.StartNew(() => CustomerAction("甲")));
            //taskList.Add(taskFactory.StartNew(() => CustomerAction("已")));
            //taskList.Add(taskFactory.StartNew(() => CustomerAction("丙")));
            //Task.WaitAll(taskList.ToArray());

            // Console.WriteLine("**********点评最高的菜是{0},评分是{1}**********", BestDishName, BestDishPoint);


            AbstracDish abstracDish = DishFactory.CreateDishInstance("FriedCurryBeef");
            abstracDish = new DishDecorator(abstracDish);
            abstracDish.CookDish();
            abstracDish.CommentsDish("张三");
            abstracDish.TasteDish("张三");
        }


        private static void CustomerAction(string customerName)
        {
            Console.WriteLine("客户{0}进入饭店", customerName);
            Console.WriteLine("客户{0},**********初始化菜单**********", customerName);
            MenuFactory menuFactory = MenuFactory.CreateInstance();
            Dictionary<int, string> dictionary = menuFactory.ShowMenu(customerName);
            if (dictionary.Keys.Any())
            {
                Console.WriteLine("客户{0},**********菜单呈现结束,开始点菜**********", customerName);
                List<int> listInt = dictionary.Keys.ToList();
                List<int> ramdomList = listInt.OrderBy(i => Guid.NewGuid()).Take(3).ToList();
                double maxDishPoint = 0;
                string maxDishName = string.Empty;
                foreach (var item in ramdomList)
                {
                    Thread.Sleep(500);
                    string className = dictionary[item];
                    AbstracDish instance = DishFactory.CreateDishInstance(className);
                    Console.WriteLine("客户{0},**********点菜，菜名{1}**********", customerName, instance.DishName);
                    instance = new DishDecorator(instance);
                    instance = new AfterDishDecorator(instance);
                    instance.CookDish();
                    instance.TasteDish(customerName);
                    double nowDishPoint = instance.CommentsDish(customerName);
                    if (nowDishPoint > maxDishPoint)
                    {
                        maxDishPoint = nowDishPoint;
                        maxDishName = instance.DishName;
                    }
                }
                Console.WriteLine("客户{0},**********点评最高的菜是{1},评分是{2}**********", customerName, maxDishName, maxDishPoint);
                if (BestDishPoint > maxDishPoint)
                {
                    lock (_BestLock)
                    {
                        if (BestDishPoint > maxDishPoint)
                        {
                            BestDishPoint = maxDishPoint;
                            BestDishName = maxDishName;
                        }
                    }
                }

            }
            Console.WriteLine("客户{0}离开饭店", customerName);

        }

    }
}
