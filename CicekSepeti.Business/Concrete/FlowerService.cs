using CicekSepeti.Business.Abstract;
using CicekSepeti.DAL.Context;
using CicekSepeti.DAL.Dto.Flower;
using CicekSepeti.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Concrete
{
    public class FlowerService : IFlowerService
    {
        private readonly CicekSepetiDbContext _cicekSepetiDbContext;
        public FlowerService(CicekSepetiDbContext cicekSepetiDbContext)
        {
            _cicekSepetiDbContext = cicekSepetiDbContext;
        }

        public async Task<int> AddFlower(AddFlowerDto addFlowerDto)
        {
            var addingFlower = new Flower
            {
                Name = addFlowerDto.Name,
                Type = addFlowerDto.Type,
                CustomerId = addFlowerDto.CustomerId
            };
            await _cicekSepetiDbContext.Flowers.AddAsync(addingFlower);
            return await _cicekSepetiDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteFlower(int FlowerId)
        {
            var currentFlower = await _cicekSepetiDbContext.Flowers.Where(p => !p.IsDeleted && p.Id == FlowerId).FirstOrDefaultAsync();
            if (currentFlower == null)
            {
                return -1;
            }
            currentFlower.IsDeleted = true;
            _cicekSepetiDbContext.Flowers.Update(currentFlower);
            return await _cicekSepetiDbContext.SaveChangesAsync();
        }

        public async Task<List<GetListFlowerDto>> GetAllFlowers()
        {
            return await _cicekSepetiDbContext.Flowers.Where(p => !p.IsDeleted).Select(p => new GetListFlowerDto
            {
                Id = p.Id,
                Name = p.Name,
                Type = p.Type,
                CustomerName = p.CustomerFK.Name,
                CustomerNumber = p.CustomerFK.CustomerNo
            }).ToListAsync();
        }

        public async Task<GetFlowerDto> GetFlowerById(int FlowerId)
        {
            return await _cicekSepetiDbContext.Flowers.Where(p => !p.IsDeleted && p.Id == FlowerId).Select(p => new GetFlowerDto
            {
                Id = p.Id,
                Name = p.Name,
                Type = p.Type,
                CustomerName = p.CustomerFK.Name,
                CustomerNumber = p.CustomerFK.CustomerNo
            }).FirstOrDefaultAsync();


        }

        public async Task<int> UpdateFlower(UpdateFlowerDto updateFlowerDto)
        {
            var currentFlower = await _cicekSepetiDbContext.Flowers.Where(p => !p.IsDeleted && p.Id == updateFlowerDto.Id).FirstOrDefaultAsync();
            if (currentFlower == null)
            {
                return -1;
            }

            currentFlower.Name = updateFlowerDto.Name;
            currentFlower.Type = updateFlowerDto.Type;
            currentFlower.CustomerId = updateFlowerDto.CustomerId;

            _cicekSepetiDbContext.Flowers.Update(currentFlower);
            return await _cicekSepetiDbContext.SaveChangesAsync();
        }
    }
}
