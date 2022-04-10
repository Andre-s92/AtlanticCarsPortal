using AtlanticCarsPortal.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCarsPortal.Domain.Decorator
{
    public class TurboDecorator : CarDecorator
    {
        public TurboDecorator(CarProtocol carProtocol) : base(carProtocol)
        {
        }
        public override decimal Price { get { return base.Price + base.Price * (decimal)0.10; } }
        public override decimal AverageSpeed { get { return base.AverageSpeed + base.AverageSpeed * (decimal)0.15; } }
        public override decimal KMPerLiter { get { return base.KMPerLiter - base.KMPerLiter * (decimal)0.30; } }
        public override int CarType { get { return (int)CarEnum.Turbo; } }
        public override string? Model { get { return base.Model + " Turbo"; } }
    }
}
