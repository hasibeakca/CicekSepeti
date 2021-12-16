using CicekSepeti.Business.Abstract;
using CicekSepeti.DAL.Context;
using CicekSepeti.DAL.Dto.FloristFlower;
using CicekSepeti.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Concrete
{
    public class FloristFlowerService : IFloristFlowerService
    {
        private readonly CicekSepetiDbContext _cicekSepetiDbContext;
        public FloristFlowerService(CicekSepetiDbContext cicekSepetiDbContext)
        {
            _cicekSepetiDbContext = cicekSepetiDbContext;
        }

        public async Task<int> AddFloristFlower(AddFloristFlowerDto addFloristFlowerDto)
        {
            var addingFloristFlower = new FloristFlower
            {
                FloristId = addFloristFlowerDto.FloristId,
                FlowerId = addFloristFlowerDto.FlowerId

            };
            await _cicekSepetiDbContext.FloristFlowers.AddAsync(addingFloristFlower);
            return await _cicekSepetiDbContext.SaveChangesAsync();

        }

        public async Task<int> DeleteFloristFlower(int FloristFlowerId)
        {
            var currentFloristFlower = await _cicekSepetiDbContext.FloristFlowers.Include(p => p.FloristFK).Include(p => p.FlowerFK).Where(p => !p.IsDeleted && p.Id == FloristFlowerId).FirstOrDefaultAsync();
            if (currentFloristFlower == null)
            {
                return -1;
            }
            currentFloristFlower.IsDeleted = true;
            _cicekSepetiDbContext.FloristFlowers.Update(currentFloristFlower);
            return await _cicekSepetiDbContext.SaveChangesAsync();
        }

        public async Task<List<GetListFloristFlowerDto>> GetAllFloristFlowers()
        {
            return await _cicekSepetiDbContext.FloristFlowers.Include(p => p.FloristFK).Include(p => p.FlowerFK).Where(p => !p.IsDeleted).Select(p => new GetListFloristFlowerDto
            {
                Id = p.Id,
                FloristId = p.FlowerFK.Id,
                FlowerName = p.FlowerFK.Name,
                FlowerId = p.FloristFK.Id,
                FloristName = p.FloristFK.Name,
                FloristNumber = p.FloristFK.FloristNumber
            }).ToListAsync();
        }

        public async Task<GetFloristFlowerDto> GetFloristFlowerById(int FloristFlowerId)
        {
            return await _cicekSepetiDbContext.FloristFlowers.Include(p => p.FloristFK).Include(p => p.FlowerFK).Where(p => !p.IsDeleted && p.Id == FloristFlowerId).Select(p => new GetFloristFlowerDto
            {
                Id = p.Id,
                FloristId = p.FlowerFK.Id,
                FlowerName = p.FlowerFK.Name,
                FlowerId = p.FloristFK.Id,
                FloristName = p.FloristFK.Name,
                FloristNumber = p.FloristFK.FloristNumber
            }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateFloristFlower(UpdateFloristFlowerDto updateFloristFlowerDto)
        {
            var currentFloristFlower = await _cicekSepetiDbContext.FloristFlowers.Where(p => !p.IsDeleted && p.Id == updateFloristFlowerDto.Id).FirstOrDefaultAsync();
            if (currentFloristFlower == null)
            {
                return -1;
            }
            currentFloristFlower.FloristId = updateFloristFlowerDto.FloristId;
            currentFloristFlower.FlowerId = updateFloristFlowerDto.FlowerId;
            _cicekSepetiDbContext.FloristFlowers.Update(currentFloristFlower);
            return await _cicekSepetiDbContext.SaveChangesAsync();
        }
    }
}
