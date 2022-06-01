using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dblibrary.models
{
    public class address
    {
        
        [Key,ForeignKey("FK_user")]
        public int userid { get; set; } // FK PK
        public string country { get; set; }
        public int zipcode { get; set; }

        // nagivation property
        public user? user { get; set; }
    }
}
