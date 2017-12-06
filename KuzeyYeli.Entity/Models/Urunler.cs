namespace KuzeyYeli.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urunler")]
    public partial class Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urunler()
        {
            Satis_Detaylari = new HashSet<Satis_Detaylari>();
        }

        [Key]
        public int UrunID { get; set; }

        [Required]
        [StringLength(150)]
        public string UrunAdi { get; set; }

        public int? TedarikciID { get; set; }

        public int? KategoriID { get; set; }

        [StringLength(20)]
        public string BirimdekiMiktar { get; set; }

        [Column(TypeName = "money")]
        public decimal? BirimFiyati { get; set; }

        public short? HedefStokDuzeyi { get; set; }

        public short? YeniSatis { get; set; }

        public short? EnAzYenidenSatisMikatari { get; set; }

        public bool Sonlandi { get; set; }

        public virtual Kategoriler Kategoriler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satis_Detaylari> Satis_Detaylari { get; set; }

        public virtual Tedarikciler Tedarikciler { get; set; }
    }
}
