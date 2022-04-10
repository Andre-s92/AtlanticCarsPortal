using AtlanticCarsPortal.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlanticCarsPortal.Domain
{
    public class Car: CarProtocol
    {
        [Required]
        public int Id { get; set; }
        [MinLength(5), MaxLength(100)]
        public string? Model { get; set; }
        [Column(TypeName = "decimal(14, 2)")]
        public decimal Price { get; set; }
        [NotMapped]
        [Column(TypeName = "decimal(14, 2)")]
        public decimal Autonomy { get => KMPerLiter * QtdTankLiter; set { } }
        [Column(TypeName = "decimal(14, 2)")]
        public decimal KMPerLiter { get; set; }
        [Column(TypeName = "decimal(14, 2)")]
        public decimal TankCapacity { get; set; }
        [Column(TypeName = "decimal(14, 2)")]
        public decimal QtdTankLiter { get; set; }
        [Column(TypeName = "decimal(14, 2)")]
        public decimal AverageSpeed { get; set; }
        public int CarType { get; set; }
    }
}