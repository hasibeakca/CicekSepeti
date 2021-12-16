using CicekSepeti.Business.Abstract;
using CicekSepeti.DAL.Context;
using CicekSepeti.DAL.Dto.FloristCustomer;
using CicekSepeti.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Concrete
{
    public class FloristCustomerService : IFloristCustomerService
    {
        private readonly CicekSepetiDbContext _cicekSepetiDbContext;

        public FloristCustomerService(CicekSepetiDbContext cicekSepetiDbContext)
        {
            _cicekSepetiDbContext = cicekSepetiDbContext;
        }

        public async Task<int> AddFloristCustomer(AddFloristCustomerDto addFloristCustomerDto)
        {
            var addingFloristCustomer = new FloristCustomer
            {
                FloristId = addFloristCustomerDto.FloristId,
                CustomerId = addFloristCustomerDto.CustomerId
            };
            await _cicekSepetiDbContext.FloristCustomers.AddAsync(addingFloristCustomer);
            return await _cicekSepetiDbContext.SaveChangesAsync();
        }



        public async Task<int> DeleteFloristCustomer(int FloristCustomerId)
        {
            var curretFloristCustomer = await _cicekSepetiDbContext.FloristCustomers.Include(p => p.FloristFK)
                  .Include(p => p.CustomerFK).Where(p => !p.IsDeleted && p.Id == FloristCustomerId).FirstOrDefaultAsync();
            if (curretFloristCustomer == null)
            {
                return -1;

            }
            curretFloristCustomer.IsDeleted = true;
            _cicekSepetiDbContext.FloristCustomers.Update(curretFloristCustomer);
            return await _cicekSepetiDbContext.SaveChangesAsync();


        }

        public async Task<List<GetListFloristCustomerDto>> GetAllFloristCustomers()
        {
            return await _cicekSepetiDbContext.FloristCustomers.Include(p => p.FloristFK).Include(p => p.CustomerFK)
                  .Where(p => !p.IsDeleted).Select(p => new GetListFloristCustomerDto
                  {
                      Id = p.Id,
                      CustomerId = p.CustomerFK.Id,
                      CustomerName = p.CustomerFK.Name,
                      FloristId = p.FloristFK.Id,
                      FloristName = p.FloristFK.Name,
                      FloristNumber = p.FloristFK.FloristNumber
                  }).ToListAsync();
        }

        public async Task<GetFloristCustomerDto> GetFloristCustomerById(int FloristCustomerId)
        {
            return await _cicekSepetiDbContext.FloristCustomers.Include(p => p.FloristFK).Include(p => p.CustomerFK)
                 .Where(p => !p.IsDeleted && p.Id == FloristCustomerId).Select(p => new GetFloristCustomerDto
                 {
                     Id = p.Id,
                     CustomerId = p.CustomerFK.Id,
                     CustomerName = p.CustomerFK.Name,
                     FloristId = p.FloristFK.Id,
                     FloristName = p.FloristFK.Name,
                     FloristNumber = p.FloristFK.FloristNumber

                 }).FirstOrDefaultAsync();

        }

        public async Task<int> UpdateFloristCustomer(UpdateFloristCustomerDto updateFloristCustomerDto)
        {
            var curretFloristCustomer = await _cicekSepetiDbContext.FloristCustomers.Where(p => !p.IsDeleted && p.Id == updateFloristCustomerDto.Id).FirstOrDefaultAsync();
            if (curretFloristCustomer == null)
            {
                return -1;

            }
            curretFloristCustomer.FloristId = updateFloristCustomerDto.FloristId;
            curretFloristCustomer.CustomerId = updateFloristCustomerDto.CustomerId;


            _cicekSepetiDbContext.FloristCustomers.Update(curretFloristCustomer);
            return await _cicekSepetiDbContext.SaveChangesAsync();
        }
    }
}
