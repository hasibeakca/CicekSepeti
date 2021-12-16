using CicekSepeti.Business.Abstract;
using CicekSepeti.Business.Validation.FloristCustomer;
using CicekSepeti.DAL.Dto.FloristCustomer;
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
    public class FloristCustomerController : ControllerBase
    {
        private readonly IFloristCustomerService _floristCustomerService;
       
        public FloristCustomerController(IFloristCustomerService floristCustomerService)
        {
            _floristCustomerService = floristCustomerService;
        }

        [HttpGet]
        [Route("GetFloristCustomerList")]
        public async Task<ActionResult<List<GetListFloristCustomerDto>>> GetFloristCustomerList()
        {
            try
            {
                return Ok(await _floristCustomerService.GetAllFloristCustomers());
            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpGet]
        [Route("GetFloristCustomerById/{id:int}")]
        public async Task<ActionResult<GetFloristCustomerDto>> GetFloristCustomer(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("FloristCustomer ıd gecersiz");
                return Ok(new { code = StatusCode(1001), Message = list, type = "error" });
            }
            try
            {
                var currentFloristCustomer = await _floristCustomerService.GetFloristCustomerById(id);
                if (currentFloristCustomer == null)
                {
                    list.Add("FloristCustomer bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentFloristCustomer;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddFloristCustomer")]
        public async Task<ActionResult<string>> AddFloristCustomer(AddFloristCustomerDto addFloristCustomerDto)
        {
            var list = new List<string>();
            var validator = new AddFloristCustomerValidator();
            var validationResults = validator.Validate(addFloristCustomerDto);
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
                var result = await _floristCustomerService.AddFloristCustomer(addFloristCustomerDto);
                if (result > 0)
                {
                    list.Add("EKLEME ISLEMI BASARILI.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else
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
        [Route("UpdateFloristCustomer")]
        public async Task<ActionResult<string>> UpdateFloristCustomer(UpdateFloristCustomerDto updateFloristCustomerDto)
        {
            var list = new List<string>();
            var validator = new UpdateFloristCustomerValidator();
            var validationResults = validator.Validate(updateFloristCustomerDto);
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
                var result = await _floristCustomerService.UpdateFloristCustomer(updateFloristCustomerDto);
                if (result < 0)
                {
                    list.Add("GUNCELLEME BASARISIZ");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                if (result == -1)
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
        [Route("DeleteFloristCustomer/{id:int}")]
        public async Task<ActionResult<string>> DeleteFloristCustomer(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _floristCustomerService.DeleteFloristCustomer(id);
                if (result <= 0)
                {
                    list.Add("SİLME İŞLEMİ BAŞARISIZ");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else if (result == -1)
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
