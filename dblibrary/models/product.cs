using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dblibrary.models
{
    public class product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productid { get; set; } // PK

        public string productname { get; set; }

        public int price { get; set; }


    }
}
