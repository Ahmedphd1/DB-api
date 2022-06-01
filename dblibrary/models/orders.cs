using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dblibrary.models
{
    public class orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderid { get; set; } // PK

        [ForeignKey("FK_product")]
        public int productid { get; set; } // FK

        [ForeignKey("FK_user")]
        public int userid { get; set; } // FK

        [ForeignKey("FK_delivery")]
        public int deliveryid { get; set; } // FK

        [ForeignKey("FK_payment")]
        public int paymentid { get; set; } // FK

        // navigation property
        public product? product { get; set; }
        public user? user { get; set; }
        public delivery? delivery { get; set; }
        public payment? payment { get; set; }

    }
}
