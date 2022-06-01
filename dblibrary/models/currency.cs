using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace dblibrary.models
{
    public class currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int currencyid { get; set; } // PK
        public string currencyname { get; set; }
        public List<currencyuser>? currencyuser { get; set; }
    }
}
