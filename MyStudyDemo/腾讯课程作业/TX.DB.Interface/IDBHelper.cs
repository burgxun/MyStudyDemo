using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TX.Model;

namespace TX.DB.Interface
{
    public interface IDBHelper
    {
        T GetT<T>(int id) where T : BaseModel, new();

        bool UpdateT<T>(T model) where T : BaseModel;

        bool DeleteT<T>(int id) where T : BaseModel;

        T InsertT<T>(T model) where T : BaseModel;
    }
}
