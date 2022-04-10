using AtlanticCarsPortal.Data.Context;
using AtlanticCarsPortal.Data.IRepository;
using AtlanticCarsPortal.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCarsPortal.Data.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Car>> GetAllCars()
        {
            IQueryable<Car> query = _context.Cars.AsNoTracking();
            return await query.OrderBy(e=> e.Id).ToArrayAsync();
        }

        public async Task<IEnumerable<Car>> GetAllCarsByType(int type)
        {
            IQueryable<Car> query = _context.Cars.AsNoTracking();
            return await query.OrderBy(e => e.Id).Where(e=> e.CarType == type).ToArrayAsync();
        }

        public async Task<Car> GetCarById(int id)
        {
            IQueryable<Car> query = _context.Cars.AsNoTracking();
            return await query.OrderBy(e => e.Id).Where(e => e.Id == id).SingleAsync();
        }
    }
}
