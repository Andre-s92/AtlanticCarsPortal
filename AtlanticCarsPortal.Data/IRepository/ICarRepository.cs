using AtlanticCarsPortal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCarsPortal.Data.IRepository
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCarsByType(int type);
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetCarById(int id);
    }
}
