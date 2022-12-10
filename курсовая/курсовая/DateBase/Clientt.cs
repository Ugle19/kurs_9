namespace курсовая.DateBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Clientt")]
    public partial class Clientt
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        public string surname { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string second_surname { get; set; }

        [Required]
        public string phone { get; set; }

        public int seria { get; set; }

        public int nomer { get; set; }

        [Required]
        public string login { get; set; }

        [Required]
        public string password { get; set; }
    }
}
