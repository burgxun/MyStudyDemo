using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX.Model
{
    public class BaseModel
    {
        [PrimaryKey(true)]
        public int Id { get; set; }
    }
}
