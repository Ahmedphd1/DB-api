using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dblibrary
{
    public class book
    {
        public int bookid { get; set; }
        public string title { get; set; }
        public int pages { get; set; }
        public double wordcount { get; set; }

        public bool binding { get; set; }

        public DateTime releaseyear { get; set; }
    }
}
