using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TX.Homework.Model;

namespace TX.Homework.Factory
{
    public class MenuFactory
    {
        private static readonly string _MenuJsonFileName = "Menu.json";
        private static MenuFactory _MenuFactory = null;
        private static object _SingleInstanceLock = new object();

        private List<BaseMenu> listDist = new List<BaseMenu>();
        private MenuFactory()
        {
            listDist = CommonFactory.GetConfigData<List<BaseMenu>>(_MenuJsonFileName);
        }

        public static MenuFactory CreateInstance()
        {
            if (_MenuFactory == null)
            {
                lock (_SingleInstanceLock)
                {
                    if (_MenuFactory == null)
                    {
                        _MenuFactory = new MenuFactory();
                    }
                }
            }
            return _MenuFactory;
        }

        public Dictionary<int, string> ShowMenu(string cutomerName)
        {
            Dictionary<int, string> dicIdAndName = new Dictionary<int, string>();
            if (listDist.Any())
            {
                Console.WriteLine("客户{0},***********下面时菜单内容**********", cutomerName);
                listDist.ForEach(dishItem =>
                {
                    Thread.Sleep(500);
                    Console.WriteLine("客户{2},菜单序号{0}--名称：{1}", dishItem.Id, dishItem.Name, cutomerName);
                    dicIdAndName.Add(dishItem.Id, dishItem.ClassName);
                });
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("客户{0},***************菜单初始化异常***************", cutomerName);
            }
            return dicIdAndName;
        }
    }
}
