using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TX.Homework.Interface;
using System.IO;
using TX.Homework.Model;
using Newtonsoft.Json;
using System.Reflection;
using System.Configuration;

namespace TX.Homework.Factory
{
    public class DishFactory
    {
        private static readonly string _DishDetailJsonFileName = "DishDetail.json";
        private static readonly string _DishClasNamespace = ConfigurationManager.AppSettings["DishClassNameSpace"].ToString();

        public static AbstracDish CreateDishInstance(string className)
        {
            try
            {
                Assembly assembly = Assembly.Load(_DishClasNamespace);
                Type type = assembly.GetType(_DishClasNamespace + "." + className);
                AbstracDish model = (AbstracDish)Activator.CreateInstance(type);
                List<BaseDish> list = CommonFactory.GetConfigData<List<BaseDish>>(_DishDetailJsonFileName);
                if (list != null && list.Any(a => a.ClassName == className))
                {
                    BaseDish baseDish = list.Where(a => a.ClassName == className).FirstOrDefault();
                    model.DishName = baseDish.Name;
                    model.DishPrice = baseDish.Price;
                    model.Message = baseDish.Message;
                }
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
