using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.DAL.Entities
{
    public class FloristFlower : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public int FloristId { get; set; }
        public Florist FloristFK { get; set; }
        public int FlowerId { get; set; }
        public Flower FlowerFK { get; set; }
        public bool IsDeleted { get ; set ; }
    }
}
