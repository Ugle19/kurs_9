namespace курсовая.DateBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bron")]
    public partial class bron
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public string hotel { get; set; }

        public string Room { get; set; }

        [Column("Bron")]
        public string Bron1 { get; set; }
    }
}
