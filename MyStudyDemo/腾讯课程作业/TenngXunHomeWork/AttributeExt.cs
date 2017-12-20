using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX.Model
{
    /**************自定义特性类*****************/
    /// <summary>  
    /// 作用：用来说明表名是什么  
    /// AttributeUsage:说明特性的目标元素是什么  
    /// AttributeTargets.Class：代表目标元素为Class  
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public TableAttribute(string tabelName)
        {
            this.TableName = tabelName;
        }

        public string TableName { get; set; }

    }

    /**************自定义特性类*****************/
    /// <summary>  
    /// 作用：说明列是否为主键
    /// </summary>  
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {
        public PrimaryKeyAttribute(bool isPKValue)
        {
            this.IsPKValue = isPKValue;
        }
        public bool IsPKValue { get; set; }
    }


}
