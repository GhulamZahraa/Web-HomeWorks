using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Web_HomeWork4_1__BootStrap.Models;

namespace Web_HomeWork4_1__BootStrap.Controllers
{
    public class CarsController : Controller
    {
        private static List<Car> availableCars = new List<Car>
        {
            new Car { Id = 1, Name = "Alto", PricePerDay = 3000m },
            new Car { Id = 2, Name = "Corolla", PricePerDay = 6000m },
            new Car { Id = 3, Name = "Civic", PricePerDay = 8000m }
        };
        private static List<Car> bookedCars = new List<Car>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(availableCars);
        }
        // Task 2 POST,Book a car

        [HttpPost]
        public IActionResult Book(int id)
        {
            Car car = null;
            for (int i = 0; i < availableCars.Count; i++)
            {
                if (availableCars[i].Id == id)
                {
                    car = availableCars[i];
                    break;
                }
            }
            if (car == null)
            {
                return RedirectToAction("Index");
            }
            availableCars.Remove(car);
            bookedCars.Add(car);
            return RedirectToAction("Booked");
        }

        // Task 2 GET,Display booked cars
        [HttpGet]
        public IActionResult Booked()
        {
            return View(bookedCars);
        }
    }
}
