using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TX.DB.Interface;

namespace TX.Factory
{
    public class SimpleFactory
    {
        private static readonly string dbConfigString = ConfigurationManager.AppSettings["DBConfig"];

        public static Tuple<bool, IDBHelper> GetDBHeler()
         {
            try
            {
                if (string.IsNullOrEmpty(dbConfigString) || dbConfigString.Split('#').Length != 2)
                    return new Tuple<bool, IDBHelper>(false, null);
                string assemblyName = dbConfigString.Split('#')[0];
                string typeName = dbConfigString.Split('#')[1];
                Assembly assembly = Assembly.Load(assemblyName);
                Type type = assembly.GetType(typeName);

                var instance = Activator.CreateInstance(type);

                return new Tuple<bool, IDBHelper>(true, (IDBHelper)instance);
            }
            catch (Exception ex)
            {
                return new Tuple<bool, IDBHelper>(false, null);
            }
        }
    }
}
