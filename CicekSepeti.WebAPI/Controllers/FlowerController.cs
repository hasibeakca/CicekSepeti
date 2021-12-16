using CicekSepeti.Business.Abstract;
using CicekSepeti.Business.Validation.Flower;
using CicekSepeti.DAL.Dto.Flower;
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
    public class FlowerController : ControllerBase
    {
        private readonly IFlowerService _flowerService;
        public FlowerController(IFlowerService flowerService)
        {
            _flowerService = flowerService;
        }
        [HttpGet]
        [Route("GetFlowerList")]
        public async Task<ActionResult<List<GetListFlowerDto>>> GetFlowerList()
        {
            try
            {
                return Ok(await _flowerService.GetAllFlowers());

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpGet]
        [Route("GetFlowerById/{id:int}")]
        public async Task<ActionResult<GetFlowerDto>> GetFlower(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Flower ıd gecersiz");
                return Ok(new { code = StatusCode(1001), Message = list, type = "error" });
            }
            try
            {
                var currentFlower = await _flowerService.GetFlowerById(id);
                if (currentFlower == null)
                {
                    list.Add("Flower bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentFlower;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddFlower")]
        public async Task<ActionResult<string>> AddFlower(AddFlowerDto addFlowerDto)
        {
            var list = new List<string>();
            var validator = new AddFlowerValidator();
            var validationResults = validator.Validate(addFlowerDto);
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
                var result = await _flowerService.AddFlower(addFlowerDto);
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
        [Route("UpdateFlower")]
        public async Task<ActionResult<string>> UpdateFlower(UpdateFlowerDto updateFlowerDto)
        {
            var list = new List<string>();
            var validator = new UpdateFlowerValidator();
            var validationResults = validator.Validate(updateFlowerDto);
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
                var result = await _flowerService.UpdateFlower(updateFlowerDto);
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
        [Route("DeleteFlower/{id:int}")]
        public async Task<ActionResult<string>> DeleteFlower(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _flowerService.DeleteFlower(id);
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
