using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CicekSepeti.DAL.Entities
{
    public class Flower : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsDeleted { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerFK { get; set; }
        public ICollection<FloristFlower> FloristFlowers { get; set; }
        
    }
}
