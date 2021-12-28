using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStore.EFModels.Model
{
    public class BuyerDetails
    {
        public int book_id { get; set; }
         
        public string buyer_name { get; set; }
        public string buyer_address { get; set; }
        [Key]
        public int IndexId { get; set; }
    }
}
