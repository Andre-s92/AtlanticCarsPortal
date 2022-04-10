using AtlanticCarsPortal.Domain;
using AtlanticCarsPortal.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace AtlanticCarsPortal.Data.Seed
{
    public static class ModelSeed
    {
        public static void SeedModel(this ModelBuilder builder)
        {
            SeedCar(builder);
        }

        private static void SeedCar(ModelBuilder builder)
        {
            builder.Entity<Car>().HasData(new Car()
            {
                Id = 1,
                Model = "Toyota Corolla",
                TankCapacity = 50,
                AverageSpeed = 205,
                KMPerLiter = 12,
                Price = 140000,
                QtdTankLiter = 20,
                CarType = (int)CarEnum.Basic
            });
            builder.Entity<Car>().HasData(new Car()
            {
                Id=2,
                Model = "Chevrolet Onix",
                TankCapacity = 54,
                AverageSpeed = 167,
                KMPerLiter = (decimal)12.9,
                Price = 75000,
                QtdTankLiter = 30,
                CarType = (int)CarEnum.Basic
            });
            builder.Entity<Car>().HasData(new Car()
            {
                Id = 3,
                Model = "Chevrolet Prisma",
                TankCapacity = 54,
                AverageSpeed = 180,
                KMPerLiter = (decimal)12.9,
                Price = 65000,
                QtdTankLiter = 35,
                CarType = (int)CarEnum.Basic
            });
            builder.Entity<Car>().HasData(new Car()
            {
                Id = 4,
                Model = "Volkswagen Gol",
                TankCapacity = 55,
                AverageSpeed = 177,
                KMPerLiter = (decimal)11.1,
                Price = 73000,
                QtdTankLiter = 35,
                CarType = (int)CarEnum.Economic
            });
            builder.Entity<Car>().HasData(new Car()
            {
                Id = 5,
                Model = "Volkswagen Voyage",
                TankCapacity = 55,
                AverageSpeed = 185,
                KMPerLiter = (decimal)11.1,
                Price = 85000,
                QtdTankLiter = 35,
                CarType = (int)CarEnum.Basic
            });
            builder.Entity<Car>().HasData(new Car()
            {
                Id = 6,
                Model = "Fiat Palio",
                TankCapacity = 48,
                AverageSpeed = 187,
                KMPerLiter = (decimal)10.1,
                Price = 55000,
                QtdTankLiter = 25,
                CarType = (int)CarEnum.Basic
            });
            builder.Entity<Car>().HasData(new Car()
            {
                Id = 7,
                Model = "Fiat Argo",
                TankCapacity = 48,
                AverageSpeed = 184,
                KMPerLiter = (decimal)10.1,
                Price = 80000,
                QtdTankLiter = 15,
                CarType = (int)CarEnum.Turbo
            });
            builder.Entity<Car>().HasData(new Car()
            {
                Id = 8,
                Model = "Fiat Toro",
                TankCapacity = 60,
                AverageSpeed = 195,
                KMPerLiter = (decimal)10.1,
                Price = 180000,
                QtdTankLiter = 40,
                CarType = (int)CarEnum.Basic
            });
            builder.Entity<Car>().HasData(new Car()
            {
                Id = 9,
                Model = "Toyota Hilux",
                TankCapacity = 80,
                AverageSpeed = 180,
                KMPerLiter = (decimal)9,
                Price = 285000,
                QtdTankLiter = 40,
                CarType = (int)CarEnum.Basic
            });
            builder.Entity<Car>().HasData(new Car()
            {
                Id = 10,
                Model = "Toyota SW4",
                TankCapacity = 80,
                AverageSpeed = 180,
                KMPerLiter = (decimal)9,
                Price = 386000,
                QtdTankLiter = 40,
                CarType = (int)CarEnum.Basic
            });


        }
    }
}
