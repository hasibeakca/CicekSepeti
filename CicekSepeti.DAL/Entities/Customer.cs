using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.DAL.Entities
{
    public class Customer : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public int CustomerNo { get; set; }
        public string  Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Flower> Flowers { get; set; }
        public ICollection<FloristCustomer> FloristCustomers { get; set; }
    }
}
