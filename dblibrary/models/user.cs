using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace dblibrary.models
{
    public class user
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userid { get; set; } // PK
        public string username { get; set; }
        public string password { get; set; }

        // navigation property
        public address? address { get; set; }
        public List<currencyuser>? currencyuser { get; set; }
    }
}
