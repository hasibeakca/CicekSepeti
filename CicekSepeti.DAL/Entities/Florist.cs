using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.DAL.Entities
{
    public class Florist : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public int FloristNumber { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string CustomerName { get; set; }
        public ICollection<FloristCustomer> FloristCustomers { get; set; }
        public ICollection<FloristFlower> FloristFlowers { get; set; }
    }
}
