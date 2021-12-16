using CicekSepeti.Business.Abstract;
using CicekSepeti.Business.Validation.Florist;
using CicekSepeti.DAL.Dto.Florist;
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
    public class FloristController : ControllerBase
    {
        private readonly IFloristService _floristService;
        public FloristController(IFloristService floristService)
        {
            _floristService = floristService;
        }
        [HttpGet]
        [Route("GetFloristList")]
        public async Task<ActionResult<List<GetListFloristDto>>> GetFloristList()
        {
            try
            {
                return Ok(await _floristService.GetAllFlorists());
            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }

        }
        [HttpGet]
        [Route("GetFloristById/{id:int}")]
        public async Task<ActionResult<GetFloristDto>> GetFlorist(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Florist ıd gecersiz");
                return Ok(new { code = StatusCode(1001), Message = list, type = "error" });
            }
            try
            {
                var currentFlorist = await _floristService.GetFloristById(id);
                if (currentFlorist == null)
                {
                    list.Add("Florist bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentFlorist;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddFlorist")]
        public async Task<ActionResult<string>> AddFlorist(AddFloristDto addFloristDto)
        {
            var list = new List<string>();
            var validator = new AddFloristValidator();
            var validationResults = validator.Validate(addFloristDto);
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
                var result = await _floristService.AddFlorist(addFloristDto);
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
        [Route("UpdateFlorist")]
        public async Task<ActionResult<string>> UpdateFlorist(UpdateFloristDto updateFloristDto)
        {
            var list = new List<string>();
            var validator = new UpdateFloristValidator();
            var validationResults = validator.Validate(updateFloristDto);
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
                var result = await _floristService.UpdateFlorist(updateFloristDto);
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
        [Route("DeleteFlorist/{id:int}")]
        public async Task<ActionResult<string>> DeleteFlorist(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _floristService.DeleteFlorist(id);
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
