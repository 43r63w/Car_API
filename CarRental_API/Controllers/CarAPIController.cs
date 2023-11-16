using CarRental_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CarRental_API.Controllers
{
    [Route("api/CarAPI")]
    [ApiController]
    public class CarAPIController : ControllerBase
    {
        public IEnumerable<Car> GetCars()
        {
            return new List<Car>
            {
                new Car { Id = 1,Name="BMW"},
                new Car { Id = 2,Name="Audi"}
            };

        }


    }
}
