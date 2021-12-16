using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.DAL.Dto.Florist
{
  public  class GetFloristDto :IDto
    {
        public int Id { get; set; }
        public int FloristNumber { get; set; }
        public string Name { get; set; }
    }
}
