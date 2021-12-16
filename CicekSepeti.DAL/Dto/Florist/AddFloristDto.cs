using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.DAL.Dto.Florist
{
    public class AddFloristDto :IDto
    {
        public int FloristNumber { get; set; }
        public string Name { get; set; }
    }
}
