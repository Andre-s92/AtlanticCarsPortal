using AtlanticCarsPortal.Application;
using AtlanticCarsPortal.Application.IServices;
using AtlanticCarsPortal.Application.Services;
using AtlanticCarsPortal.Data.Context;
using AtlanticCarsPortal.Data.IRepository;
using AtlanticCarsPortal.Data.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCarsPortal.Test
{
    public class DependencySetupFixture
    {
        public DependencySetupFixture()
        {
            var connectionString = "Server=localhost;Database=AtlanticCarsPortal;Uid=root;Pwd=12345;";
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<DataContext>(
          options => options.UseMySql(connectionString,
          ServerVersion.AutoDetect(connectionString)));
            serviceCollection.AddScoped<ICarServices, CarServices>();
            serviceCollection.AddScoped<IBaseRepository, BaseRepository>();
            serviceCollection.AddScoped<ICarRepository, CarRepository>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
            ServiceProvider = serviceCollection.BuildServiceProvider();

        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
