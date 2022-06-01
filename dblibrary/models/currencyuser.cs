using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace dblibrary.models
{
    public class currencyuser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int currencyuserid { get; set; }

        [ForeignKey("FK_user")]
        public int userid { get; set; } // FK

        [ForeignKey("FK_currencies")]
        public int currencyid { get; set; } // FK

        //navigation properties

        public user? user { get; set; }

        public currency? currency { get; set; }

    }
}
