using System.ComponentModel.DataAnnotations;

namespace CarRental_API.Models.Dto
{
    public class CarDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Price { get; set; }
    }
}
