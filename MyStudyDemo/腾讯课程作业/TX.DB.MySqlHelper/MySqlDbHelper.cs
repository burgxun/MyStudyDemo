using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TX.DB.Interface;
using TX.Model;

namespace TX.DB.MySqlHelper
{
    public class MySqlDbHelper : IDBHelper
    {
        private static readonly string sqlConnectionString = string.Empty;

        public T GetT<T>(int id) where T : BaseModel, new()
        {
            return default(T);
        }

        public bool UpdateT<T>(T model) where T : BaseModel
        {
            return false;
        }

        public bool DeleteT<T>(int id) where T : BaseModel
        {
            return false;
        }

        public T InsertT<T>(T model) where T : BaseModel
        {
            return default(T);
        }
    }
}
