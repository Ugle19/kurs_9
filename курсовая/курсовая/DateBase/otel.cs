namespace курсовая.DateBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("otel")]
    public partial class otel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Nomer_hotel { get; set; }

        [Key]
        [Column(Order = 1)]
        public string N { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Gorod { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Adress { get; set; }

        [Key]
        [Column(Order = 4)]
        public string Nomer_tel { get; set; }
    }
}
