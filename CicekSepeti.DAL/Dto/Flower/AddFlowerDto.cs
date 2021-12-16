using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.DAL.Dto.Flower
{
    public class AddFlowerDto : IDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int CustomerId { get; set; }
    }
}
