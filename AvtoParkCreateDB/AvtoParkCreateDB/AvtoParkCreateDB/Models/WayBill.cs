namespace AvtoParkCreateDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WayBill")]
    public partial class WayBill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? Cd { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DtGive { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DtReturn { get; set; }

        public int? IdVehicle { get; set; }

        public int? IdDriver { get; set; }

        public DateTime? DtOut { get; set; }

        public DateTime? DtIn { get; set; }

        public int? SpdOut { get; set; }

        public int? SpdIn { get; set; }

        public int? IdFuel { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FuelBalOut { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FuelBalIn { get; set; }

        public int? FuelFillUp { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FuelConsumNorm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FuelConsumFact { get; set; }

        public virtual DriverSpr DriverSpr { get; set; }

        public virtual FuelSpr FuelSpr { get; set; }

        public virtual VehicleSpr VehicleSpr { get; set; }
    }
}
