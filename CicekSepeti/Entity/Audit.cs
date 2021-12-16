using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entity
{
   public abstract class Audit
    {
        public DateTime CDate { get; set; }
        public DateTime? MDate { get; set; }
        public int CUserId { get; set; }
        public int? MUserId { get; set; }
    }
}
