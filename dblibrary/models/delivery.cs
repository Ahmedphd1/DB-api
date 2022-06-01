using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dblibrary.models
{
    public class delivery
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int deliveryid { get; set; } // PK
        public string method { get; set; }
    }
}
