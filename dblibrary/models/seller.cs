using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dblibrary.models
{
    public class seller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int sellerid { get; set; } // PK
        public string name { get; set; }

        [ForeignKey("productid")]
        public int productid { get; set; } // FK

        // navigation property
        public product? product { get; set; }
    }
}
