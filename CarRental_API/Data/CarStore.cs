using CarRental_API.Models.Dto;

namespace CarRental_API.Data
{
    public static class CarStore
    {

        public static List<CarDto> carsLists = new List<CarDto>
            {
                new CarDto { Id = 1,Name="BMW"},
                new CarDto { Id = 2,Name="Audi"}
            };
    }
}
