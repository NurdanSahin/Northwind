namespace KuzeyYeli.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonellerYeni")]
    public partial class PersonellerYeni
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonelID { get; set; }

        [Required]
        [StringLength(20)]
        public string SoyAdi { get; set; }

        [Required]
        [StringLength(10)]
        public string Adi { get; set; }

        [StringLength(30)]
        public string Unvan { get; set; }

        [StringLength(25)]
        public string UnvanEki { get; set; }

        public DateTime? DogumTarihi { get; set; }

        public DateTime? IseBaslamaTarihi { get; set; }

        [StringLength(60)]
        public string Adres { get; set; }

        [StringLength(15)]
        public string Sehir { get; set; }

        [StringLength(15)]
        public string Bolge { get; set; }

        [StringLength(10)]
        public string PostaKodu { get; set; }

        [StringLength(15)]
        public string Ulke { get; set; }

        [StringLength(24)]
        public string EvTelefonu { get; set; }

        [StringLength(4)]
        public string Extension { get; set; }

        [Column(TypeName = "image")]
        public byte[] Fotograf { get; set; }

        [Column(TypeName = "ntext")]
        public string Notlar { get; set; }

        public int? BagliCalistigiKisi { get; set; }

        [StringLength(255)]
        public string FotografPath { get; set; }
    }
}
