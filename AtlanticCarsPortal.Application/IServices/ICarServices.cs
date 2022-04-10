using AtlanticCarsPortal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCarsPortal.Application.IServices
{
    public interface ICarServices
    {
        Task<IEnumerable<Car>> GetAllCarsByType(int type);
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetCarById(int id);
        Task<Car> GetCarByAutonomy();
        Task<Car> GetCarByDistance(int distance);
        Task<object> RefuelCar(int id, decimal amount);
        Task<object> ActivateNewType(int id, int type);
    }
}
