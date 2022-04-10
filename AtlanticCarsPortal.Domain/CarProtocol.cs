using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCarsPortal.Domain
{
    public interface CarProtocol
    {
        public int Id { get;}
        public string? Model { get;}
        public decimal Price { get;}
        public decimal Autonomy { get;}
        public decimal KMPerLiter { get;}
        public decimal TankCapacity { get;}
        public decimal QtdTankLiter { get;}
        public decimal AverageSpeed { get;}
        public int CarType { get;}
    }
}
