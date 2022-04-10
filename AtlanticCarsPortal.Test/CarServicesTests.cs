using AtlanticCarsPortal.Application.IServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AtlanticCarsPortal.Test
{

    public class CarServicesTests : IClassFixture<DependencySetupFixture>
    {
        private ServiceProvider _serviceProvider;
        public CarServicesTests(DependencySetupFixture fixture)
        {

            _serviceProvider = fixture.ServiceProvider;

        }
        [Fact]
        public async Task GetAllCars_Exists_Value()
        {
            var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ICarServices>();
            var car = await context.GetAllCars();
            Assert.NotNull(car);
        }
        [Fact]
        public async Task GetAllCars_Exists_Type_Basic()
        {
            var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ICarServices>();
            var car = await context.GetAllCars();
            var type = car.Where(x => x.CarType == 1);
            Assert.True(type.Count() > 0);
        }
        [Fact]
        public async Task GetAllCars_Exists_Type_Economic()
        {
            var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ICarServices>();
            var car = await context.GetAllCars();
            var type = car.Where(x => x.CarType == 2);
            Assert.True(type.Count() > 0);
        }
        [Fact]
        public async Task GetAllCars_Exists_Type_Turbo()
        {
            var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ICarServices>();
            var car = await context.GetAllCars();
            var type = car.Where(x => x.CarType == 3);
            Assert.True(type.Count() > 0);
        }
        [Fact]
        public async Task GetAllCars_value_Count_10()
        {
            var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ICarServices>();
            var car = await context.GetAllCars();
            Assert.Equal(10, car.Count());
        }

        [Fact]
        public async Task GetCarById_Exists()
        {
            var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ICarServices>();

            var id = 1;
            var model = "Toyota Corolla";
            var car = await context.GetCarById(id);

            Assert.Equal(id, car.Id);
            Assert.Equal(model, car.Model);
        }
        [Fact]
        public async Task GetCarByAutonomy_Exists()
        {
            var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ICarServices>();

            var car = await context.GetCarByAutonomy();
            Assert.NotNull(car);
        }
        [Fact]
        public async Task GetCarByDistance_Exists()
        {
            var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ICarServices>();

            var distance = 100;
            var car = await context.GetCarByDistance(distance);
            Assert.NotNull(car);
        }
        [Fact]
        public async Task GetAllCarsByType_Exists()
        {
            var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ICarServices>();

            var type = 1;
            var car = await context.GetAllCarsByType(type);
            Assert.NotNull(car);


        }
        [Fact]
        public async Task RefuelCar_Test_InvalidAmout()
        {
            var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ICarServices>();

            var id = 1;
            var amount = 0;
            var car = await context.RefuelCar(id, amount);
            Assert.Contains("Invalid amount", car.ToString());
        }
        [Fact]
        public async Task ActivateNewType_Test_InvalidType()
        {
            var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ICarServices>();

            var id = 1;
            var type = 0;
            var car = await context.ActivateNewType(id, type);
            Assert.Contains("Put a valid type", car.ToString());
        }
        [Fact]
        public async Task ActivateNewType_Test_Already_Activated()
        {
            var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ICarServices>();

            var id = 1;
            var type = 1;
            var car = await context.ActivateNewType(id, type);
            Assert.Contains("already activated", car.ToString());
        }

    }
}