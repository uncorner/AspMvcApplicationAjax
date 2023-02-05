using System.ComponentModel.DataAnnotations;
using TestAspMvcApplication.DataAccess;

namespace TestAspMvcApplication.Models.Forms
{
    public class CarForm
    {
        [Required]
        [StringLength(20, ErrorMessage = "Слишком длинное название!")]
        public string Name { get; set; }

        public Car GetCar()
        {
            var car = new Car {Name = Name};
            return car;
        }

    }
}