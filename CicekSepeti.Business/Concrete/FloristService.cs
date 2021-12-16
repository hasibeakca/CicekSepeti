using CicekSepeti.Business.Abstract;
using CicekSepeti.DAL.Context;
using CicekSepeti.DAL.Dto.Florist;
using CicekSepeti.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Concrete
{
    public class FloristService : IFloristService
    {
        private readonly CicekSepetiDbContext _cicekSepetiDbContext;
        public FloristService(CicekSepetiDbContext cicekSepetiDbContext)
        {
            _cicekSepetiDbContext = cicekSepetiDbContext;
        }

        public async Task<int> AddFlorist(AddFloristDto addFloristDto)
        {
            var addingFlorist = new Florist
            {
                Name = addFloristDto.Name,
                FloristNumber = addFloristDto.FloristNumber


            };
            await _cicekSepetiDbContext.Florists.AddAsync(addingFlorist);
            return await _cicekSepetiDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteFlorist(int FloristId)
        {
            var currentFlorist = await _cicekSepetiDbContext.Florists.Where(p => !p.IsDeleted && p.Id == FloristId).FirstOrDefaultAsync();
            if (currentFlorist == null)
            {
                return -1;
            }
            currentFlorist.IsDeleted = true;
            _cicekSepetiDbContext.Florists.Update(currentFlorist);
            return await _cicekSepetiDbContext.SaveChangesAsync();

        }

        public async Task<List<GetListFloristDto>> GetAllFlorists()
        {
            return await _cicekSepetiDbContext.Florists.Where(p => !p.IsDeleted).Select(p => new GetListFloristDto
            {
                Id = p.Id,
                Name = p.Name,
                FloristNumber = p.FloristNumber,
            }).ToListAsync();
        }

        public async Task<GetFloristDto> GetFloristById(int FloristId)
        {
            return await _cicekSepetiDbContext.Florists.Where(p => !p.IsDeleted && p.Id == FloristId).Select(p => new GetFloristDto
            {
                Id = p.Id,
                Name = p.Name,
                FloristNumber = p.FloristNumber,


            }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateFlorist(UpdateFloristDto updateFloristDto)
        {
            var currentFlorist = await _cicekSepetiDbContext.Florists.Where(p => !p.IsDeleted && p.Id == updateFloristDto.Id).FirstOrDefaultAsync();
            if (currentFlorist == null)
            {
                return -1;
            }

            currentFlorist.FloristNumber = updateFloristDto.FloristNumber;
            currentFlorist.Name = updateFloristDto.Name;

            _cicekSepetiDbContext.Florists.Update(currentFlorist);
            return await _cicekSepetiDbContext.SaveChangesAsync();
        }
    }
}
