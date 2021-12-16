using CicekSepeti.Business.Abstract;
using CicekSepeti.Business.Validation.Customer;
using CicekSepeti.DAL.Dto.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicekSepeti.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        [Route("GetCustomerLits")]

        public async Task<ActionResult<List<GetListCustomerDto>>> GetCustomerList()
        {
            try
            {
                return Ok(await _customerService.GetAllCustomers());
            }

            catch (Exception hata)
            {
                return BadRequest(hata.Message);

            }
        }
        [HttpGet]
        [Route("GetCustomerById/{id:int}")]
        public async Task<ActionResult<GetCustomerDto>> GetCustomer(int id)
        {
            var list = new List<string>();

            if (id <= 0)
            {
                list.Add("Customer id geçersiz");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            try
            {
                var currentCustomer = await _customerService.GetCustomerById(id);
                if (currentCustomer == null)
                {
                    list.Add("Customer bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentCustomer;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddCustomer")]
        public async Task<ActionResult<string>> AddCustomer(AddCustomerDto addCustomerDto)
        {
            var list = new List<string>();
            var validator = new AddCustomerValidator();
            var validationResults = validator.Validate(addCustomerDto);
            if (!validationResults.IsValid)
            {
                foreach(var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }

            try
            {
                var result = await _customerService.AddCustomer(addCustomerDto);
                if (result > 0)
                {
                    list.Add("EKLEME ISLEMI BASARILI.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                } else
                {
                    list.Add("EKLEME ISLEMI BASARISIZ.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<ActionResult<string>> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            var list = new List<string>();
            var validator = new UpdateCustomerValidator();
            var validationResults = validator.Validate(updateCustomerDto);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var result = await _customerService.UpdateCustomer(updateCustomerDto);
                if (result < 0)
                {
                    list.Add("GUNCELLEME BASARISIZ");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }if(result == -1)
                {
                    list.Add("GUNCELLENECEK ID BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, Type = "error" });
                }
                else
                {
                    list.Add("GUNCELLEME BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
            }
            catch (Exception hata)
            {
                return BadRequest(hata.Message);

            }
        }

        [HttpDelete]
        [Route("DeleteCustomer/{id:int}")]
        public async Task<ActionResult<string>> DeleteCustomer(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _customerService.DeleteCustomer(id);
                if (result <= 0)
                {
                    list.Add("SİLME İŞLEMİ BAŞARIISIZ");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                } else if(result == -1)
                {
                    list.Add("SİLİNECEK BIR ID BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("SİLME İŞLEMİ BAŞARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }

            }
            catch (Exception hata)
            {

                return Ok(hata.Message);
            }
        }
    }
}
