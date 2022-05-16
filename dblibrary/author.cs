using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dblibrary
{
    public class author
    {
        public int authorid { get; set; } // the PK in the database - pk = primary key
        public string name { get; set; }
        public int age { get; set; }
        public string password { get; set; }
        public bool isalive { get; set; }


    }
}
