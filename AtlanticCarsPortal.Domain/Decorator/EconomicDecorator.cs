using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtlanticCarsPortal.Domain.Enum;

namespace AtlanticCarsPortal.Domain.Decorator
{
    public class EconomicDecorator : CarDecorator
    {
        public EconomicDecorator(CarProtocol carProtocol) : base(carProtocol)
        {
        }
        public override decimal Price { get { return base.Price + base.Price*(decimal)0.05; } }
        public override decimal Autonomy { get { return base.Autonomy + base.Autonomy*(decimal)0.05; } }
        public override decimal KMPerLiter { get { return base.KMPerLiter + base.KMPerLiter * (decimal)0.10; } }
        public override int CarType { get { return (int)CarEnum.Economic; } }
        public override string? Model { get { return base.Model + " Economic"; } }
    }
}
