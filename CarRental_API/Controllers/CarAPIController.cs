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
            if (CarStore.carsLists.Count == 0)
            {
                return NoContent();
            }

            return Ok(CarStore.carsLists);
        }
        [HttpGet("id", Name = "GetCar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CarDto> GetCar(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var carFromDb = CarStore.carsLists.FirstOrDefault(u => u.Id == id);
            if (carFromDb == null)
            {
                return NotFound();
            }
            return Ok(carFromDb);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CarDto> CreateCar([FromBody] CarDto carDto)
        {


            if (CarStore.carsLists.FirstOrDefault(u => u.Name.ToLower() == carDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Car Exists");
                return BadRequest(ModelState);
            }

            if (carDto == null)
            {
                return BadRequest(carDto);
            }
            if (carDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            carDto.Id = CarStore.carsLists.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            CarStore.carsLists.Add(carDto);

            return CreatedAtRoute("GetCar", new { id = carDto.Id }, carDto);

        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CarDto> RemoveCar(int id)
        {
            var carFromList = CarStore.carsLists.FirstOrDefault(u => u.Id == id);

            if (carFromList == null)
            {
                ModelState.AddModelError("", "Bad Request!Try again");
                return BadRequest(ModelState);
            }

            CarStore.carsLists.Remove(carFromList);


            return NoContent();

        }

        [HttpDelete("RemoveRange")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<CarDto>> RemoveRange()
        {

            CarStore.carsLists.Clear();

            return NoContent();
        }

        [HttpPatch("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CarDto> Update(CarDto car)
        {
            var carLists = CarStore.carsLists.FirstOrDefault(u => u.Id == car.Id);

            carLists.Name = car.Name;


            return CreatedAtRoute("GetCar", new { id = carLists.Id }, carLists);
        }

    }
}
