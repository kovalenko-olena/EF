namespace AvtoParkEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleSpr")]
    public partial class VehicleSpr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleSpr()
        {
            WayBills = new HashSet<WayBill>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(20)]
        public string RegNumber { get; set; }

        public int? GarNumber { get; set; }

        public int? IdModel { get; set; }

        public int? IdDriver { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Norm { get; set; }

        public virtual DriverSpr DriverSpr { get; set; }

        public virtual ModelSpr ModelSpr { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WayBill> WayBills { get; set; }
    }
}
