using CicekSepeti.Business.Abstract;
using CicekSepeti.Business.Validation.FloristFlower;
using CicekSepeti.DAL.Dto.FloristFlower;
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
    public class FloristFlowerController : ControllerBase
    {
        private readonly IFloristFlowerService _floristFlowerService;
        public FloristFlowerController(IFloristFlowerService floristFlowerService)
        {
            _floristFlowerService = floristFlowerService;
        }
        [HttpGet]
        [Route("GetFloristFlowerList")]
        public async Task<ActionResult<List<GetListFloristFlowerDto>>> GetFloristFlower()
        {
            try
            {
                return Ok(await _floristFlowerService.GetAllFloristFlowers());
            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpGet]
        [Route("GetFloristFlowerById/{id:int}")]
        public async Task<ActionResult<GetFloristFlowerDto>> GetFloristFlower(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("FloristFlower ıd gecersiz");
                return Ok(new { code = StatusCode(1001), Message = list, type = "error" });
            }
            try
            {
                var currentFloristFlower = await _floristFlowerService.GetFloristFlowerById(id);
                if (currentFloristFlower == null)
                {
                    list.Add("FloristFlower bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentFloristFlower;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }

        }
        [HttpPost("AddFloristFlower")]
        public async Task<ActionResult<string>> AddFloristFlower(AddFloristFlowerDto addFloristFlowerDto)
        {
            var list = new List<string>();
            var validator = new AddFloristFlowerValidator();
            var validationResults = validator.Validate(addFloristFlowerDto);
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
                var result = await _floristFlowerService.AddFloristFlower(addFloristFlowerDto);
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
        [Route("UpdateFloristFlower")]
        public async Task<ActionResult<string>> UpdateFloristFlower(UpdateFloristFlowerDto updateFloristFlowerDto)
        {
            var list = new List<string>();
            var validator = new UpdateFloristFlowerValidator();
            var validationResults = validator.Validate(updateFloristFlowerDto);
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
                var result = await _floristFlowerService.UpdateFloristFlower(updateFloristFlowerDto);
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
        [Route("DeleteFloristFlower/{id:int}")]
        public async Task<ActionResult<string>> DeleteFloristFlower(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _floristFlowerService.DeleteFloristFlower(id);
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
