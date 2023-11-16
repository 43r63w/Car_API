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
        public IEnumerable<CarDto> GetCars()
        {

            return new List<CarDto>
            {
                new CarDto { Id = 1,Name="BMW"},
                new CarDto { Id = 2,Name="Audi"}
            };

        }


    }
}
