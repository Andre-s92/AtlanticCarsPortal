using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCarsPortal.Domain
{
    public class CarDecorator : CarProtocol
    {
        private readonly CarProtocol _carProtocol;

        public CarDecorator(CarProtocol carProtocol)
        {
            this._carProtocol = carProtocol;
        }
        public int Id => _carProtocol.Id;
        public virtual string? Model => this._carProtocol.Model;
        public virtual decimal Price => this._carProtocol.Price;
        public virtual decimal Autonomy => this._carProtocol.Autonomy;
        public virtual decimal KMPerLiter => this._carProtocol.KMPerLiter;
        public decimal TankCapacity => _carProtocol.TankCapacity;
        public decimal QtdTankLiter => _carProtocol.QtdTankLiter;
        public virtual decimal AverageSpeed => this._carProtocol.AverageSpeed;           
        public virtual int CarType => this._carProtocol.CarType;
  
    }
}
