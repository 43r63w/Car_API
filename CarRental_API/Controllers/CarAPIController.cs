using CarRental_API.Data;
using CarRental_API.Models;
using CarRental_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CarRental_API.Controllers
{
    [Route("api/CarAPI")]
    [ApiController]
    public class CarAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CarDto>> GetCars()
        {

            return Ok(CarStore.carsLists);
        }
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  ActionResult<CarDto> GetCar(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var carFromDb = CarStore.carsLists.FirstOrDefault(u=>u.Id==id);
            if(carFromDb == null)
            {
                return NotFound();
            }
            return Ok(carFromDb);  
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CarDto> CreateCar([FromBody]CarDto carDto)
        {
            if(carDto == null)
            {
                return BadRequest(carDto);
            }
            if (carDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
            carDto.Id = CarStore.carsLists.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            CarStore.carsLists.Add(carDto);

            return Ok(carDto);


        }

    }
}
