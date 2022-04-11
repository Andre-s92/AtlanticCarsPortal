using AtlanticCarsPortal.Application.IServices;
using AtlanticCarsPortal.Data.IRepository;
using AtlanticCarsPortal.Domain;
using AtlanticCarsPortal.Domain.Decorator;
using AtlanticCarsPortal.Domain.Enum;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCarsPortal.Application.Services
{
    public class CarServices : ICarServices
    {
        private readonly IBaseRepository _baseRepository;
        private readonly ICarRepository _carRepository;
        protected readonly IMapper _mapper;
        public EconomicDecorator _economic;
        public TurboDecorator _turbo;
        CarDecorator _decorator;

        public CarServices(IBaseRepository baseRepository, ICarRepository carRepository, IMapper mapper)
        {
            this._baseRepository = baseRepository;
            this._carRepository = carRepository;
            this._mapper = mapper;
        }
        
        public async Task<object> RefuelCar(int id, decimal amount)
        {
            try
            {
                if (amount < 1)
                    return "Invalid amount";
                decimal availableCapacity =0;
                var car = await _carRepository.GetCarById(id);
                if (car == null) return null;
                if (car.QtdTankLiter == car.TankCapacity)
                    return "Tank is already full";               
                availableCapacity = car.TankCapacity - car.QtdTankLiter;
                if(amount > availableCapacity)
                {
                    car.QtdTankLiter += availableCapacity;
                }
                else
                {
                    car.QtdTankLiter += amount;
                }                  
                _baseRepository.Update(car);
                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _carRepository.GetCarById(car.Id);
                }
                return null;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<object> ActivateNewType(int id, int type)
        {
            try
            {
                if (type < 1 || type > 3)
                    return "Put a valid type between 1 and 3";
                var car = await _carRepository.GetCarById(id);
                if (car == null) return null;                        
                if(car.CarType == type)
                    return "Type is already activated";
                await Task.CompletedTask;
                car.CarType = type;
                _baseRepository.Update(car);
                if (await _baseRepository.SaveChangesAsync())
                {
                    _decorator = new CarDecorator(await CheckSingleType(car));
                    return _mapper.Map<Car>(_decorator);
                }
                return null;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<Car>> GetAllCars()
        {
            try
            {
                var car = await _carRepository.GetAllCars();
                if (car == null) return null;
                var carList = new List<Car>();
                for(int i = 0; i < car.Count(); i++)
                {
                    _decorator = new CarDecorator(await CheckSingleType(car.ElementAt(i)));
                    carList.Add(_mapper.Map<Car>(_decorator));
                    
                }
                car = carList;
                return car;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<Car> GetCarById(int id)
        {
            try
            {
                var car = await _carRepository.GetCarById(id);
                if (car == null) return null;
                 _decorator = new CarDecorator(await CheckSingleType(car));
                return _mapper.Map<Car>(_decorator);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<Car> GetCarByAutonomy()
        {
            try
            {
                var car = await GetAllCars();
                if (car == null) return null;
                var result = car.OrderByDescending(x => x.Autonomy);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<Car> GetCarByDistance(int distance)
        {
            try
            {
                if (distance < 1)
                    throw new Exception("Invalid distance");
                var car = await GetAllCars();
                if (car == null) return null;
                var result = car.OrderBy(x => (((distance /x.AverageSpeed))*60)/60);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<Car>> GetAllCarsByType(int type)
        {
            try
            {
                if (type < 1 || type > 3)
                    throw new Exception("Put a valid type between 1 and 3");
                var car = await _carRepository.GetAllCarsByType(type);
                if (car == null) return null;
                var carList = new List<Car>();
                for (int i = 0; i < car.Count(); i++)
                {
                    _decorator = new CarDecorator(await CheckSingleType(car.ElementAt(i)));
                    carList.Add(_mapper.Map<Car>(_decorator));

                }
                car = carList;
                return car;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<CarProtocol> CheckSingleType(Car car)
        {

            switch (car.CarType)
            {
                case (int)CarEnum.Basic:
                    return car;
                case (int)CarEnum.Economic:
                    return _economic = new EconomicDecorator(car);
                case (int)CarEnum.Turbo:
                    return _turbo = new TurboDecorator(car);


            }
            return car;

        }


    }
}
