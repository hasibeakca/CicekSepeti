using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.DAL.Entities
{
    public class FloristCustomer : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public int FloristId { get; set; }
        public Florist FloristFK { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerFK { get; set; }
        public bool IsDeleted { get ; set ; }
    }
}
