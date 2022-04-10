using AtlanticCarsPortal.Application.IServices;
using AtlanticCarsPortal.Domain;
using AtlanticCarsPortal.Domain.Selectors;
using Microsoft.AspNetCore.Mvc;

namespace AtlanticCarsPortal.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarServices _carServices;

        public CarsController(ICarServices carServices)
        {
            this._carServices = carServices;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cars = await _carServices.GetAllCars();
                if (cars == null) return NotFound("Cars Not found");
                return Ok(cars);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"cars error : {ex.Message}");
            }

        }
        [HttpGet("CarsByType/{type}")]
        public async Task<IActionResult> GetByType(int type)
        {
            try
            {
                var cars = await _carServices.GetAllCarsByType(type);
                if (cars == null) return NotFound("Cars Not found");
                return Ok(cars);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"cars error : {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var car = await _carServices.GetCarById(id);
                if (car == null) return NotFound("Car Not found");
                return Ok(car);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"car error : {ex.Message}");
            }

        }
        [HttpGet("Distance/{distance}")]
        public async Task<IActionResult> GetByIdDistance(int distance)
        {
            try
            {
                var car = await _carServices.GetCarByDistance(distance);
                if (car == null) return NotFound("Car Not found");
                return Ok(car);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"car error : {ex.Message}");
            }

        }
        [HttpGet("BetterAutonomy")]
        public async Task<IActionResult> GetByGetCarByAutonomy()
        {
            try
            {
                var car = await _carServices.GetCarByAutonomy();
                if (car == null) return NotFound("Car Not found");
                return Ok(car);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"car error : {ex.Message}");
            }

        }
        [HttpPut("Refuel")]
        public async Task<IActionResult> RefuelCar([FromBody] RefuelCar obj)
        {
            var car = await _carServices.RefuelCar(obj.Id, obj.Amount);
            if (car == null) return BadRequest("Error car refuel");
            return Ok(car);
        }

        [HttpPut("ActivateNewType")]
        public async Task<IActionResult> ActivateNewType([FromBody] ChangeTypeCar obj)
        {
            var car = await _carServices.ActivateNewType(obj.Id, obj.Type);
            if (car == null) return BadRequest("Error car change type");
            return Ok(car);
        }
    }
}
