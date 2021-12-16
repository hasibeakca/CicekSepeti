using CicekSepeti.Business.Abstract;
using CicekSepeti.DAL.Context;
using CicekSepeti.DAL.Dto.Customer;
using CicekSepeti.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly CicekSepetiDbContext _cicekSepetiDbContext;
        public CustomerService(CicekSepetiDbContext cicekSepetiDbContext)
        {
            _cicekSepetiDbContext = cicekSepetiDbContext;
        }

        public async Task<int> AddCustomer(AddCustomerDto addCustomerDto)
        {
            var addingCustomer = new Customer
            {

                Name = addCustomerDto.Name,
                CustomerNo = addCustomerDto.CustomerNo,

            };
            await _cicekSepetiDbContext.Customers.AddAsync(addingCustomer);
            return await _cicekSepetiDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteCustomer(int CustomerId)
        {
            var currentCustomer = await _cicekSepetiDbContext.Customers.Where(p => !p.IsDeleted && p.Id == CustomerId).FirstOrDefaultAsync();

            if (currentCustomer == null)
            {
                return -1;
            }
            currentCustomer.IsDeleted = true;
            _cicekSepetiDbContext.Customers.Update(currentCustomer);
            return await _cicekSepetiDbContext.SaveChangesAsync();
        }

        public async Task<List<GetListCustomerDto>> GetAllCustomers()
        {
            return await _cicekSepetiDbContext.Customers.Where(p => !p.IsDeleted).Select(p => new GetListCustomerDto
            {
                Id = p.Id,
                Name = p.Name,
                CustomerNo = p.CustomerNo
               

            }).ToListAsync();
        }

        public async Task<GetCustomerDto> GetCustomerById(int CustomerId)
        {
            return await _cicekSepetiDbContext.Customers.Where(p => !p.IsDeleted && p.Id == CustomerId).Select(p => new GetCustomerDto
            {
                Id = p.Id,
                Name = p.Name,
                CustomerNo = p.CustomerNo
                

            }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            var currentCustomer = await _cicekSepetiDbContext.Customers.Where(p => !p.IsDeleted && p.Id == updateCustomerDto.Id).FirstOrDefaultAsync();

            if (currentCustomer == null)
            {
                return -1;
            }

            currentCustomer.CustomerNo = updateCustomerDto.CustomerNo;
            currentCustomer.Name = updateCustomerDto.Name;
            _cicekSepetiDbContext.Customers.Update(currentCustomer);
            return await _cicekSepetiDbContext.SaveChangesAsync();
        }
    }
}
