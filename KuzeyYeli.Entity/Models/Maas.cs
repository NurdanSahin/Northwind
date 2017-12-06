namespace KuzeyYeli.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Maas
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Soyadi { get; set; }

        [StringLength(11)]
        public string TCKimlikNo { get; set; }

        public decimal? Brut { get; set; }

        public decimal? Agi { get; set; }

        public decimal? SgkPrimi14 { get; set; }

        public decimal? IssizilkFonu1 { get; set; }

        public decimal? GelirVergisi { get; set; }

        public decimal? DamgaVerisi { get; set; }

        public decimal? KesintiToplami { get; set; }

        public decimal? NetUcret { get; set; }

        public decimal? SgkPrimi15 { get; set; }

        public decimal? IsverenIssizlik2 { get; set; }

        public decimal? ToplamMaliyet { get; set; }
    }
}
