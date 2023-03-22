namespace AvtoParkCreateDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModelSpr")]
    public partial class ModelSpr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModelSpr()
        {
            VehicleSprs = new HashSet<VehicleSpr>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Cd { get; set; }

        [Required]
        [StringLength(50)]
        public string CdNm { get; set; }

        public int? IdFuel { get; set; }

        public int? IdBrand { get; set; }

        public virtual BrandSpr BrandSpr { get; set; }

        public virtual FuelSpr FuelSpr { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleSpr> VehicleSprs { get; set; }
    }
}
