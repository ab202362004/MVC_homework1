namespace MVC_homework1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Classify")]
    public partial class Classify
    {
        public int ClassifyId { get; set; }

        [Required]
        [StringLength(50)]
        public string Kind { get; set; }

        [Required]
        [StringLength(50)]
        public string Desc { get; set; }

        public int Value { get; set; }
    }
}
