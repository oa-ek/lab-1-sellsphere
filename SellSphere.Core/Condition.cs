using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellSphere.Core
{
    public class Condition
    {
        [Key]
        public int ConditionId { get; set; }
        public string ConditionName { get; set; }

        public virtual ICollection<Goods> Goods { get; set; }

    }
}
