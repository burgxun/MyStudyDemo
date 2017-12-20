using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX.Model
{
    [Table("Company")]
    public class CompanyModel : BaseModel
    {
        public CompanyModel()
        {

        }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreatorId { get; set; }

        public int? LastModifierId { get; set; }

        public DateTime? LastModifyTime { get; set; }

    }
}
