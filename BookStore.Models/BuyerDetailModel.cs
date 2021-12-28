using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Models
{
    public class BuyerDetailModel
    {
        public int book_id { get; set; }
        public string buyer_name { get; set; }
        public string buyer_address { get; set; }
        public string book_name { get; set; }
         
    }

    public class BuyerInsertModel
    {
        public int book_id { get; set; }
        public string buyer_name { get; set; }
        public string buyer_address { get; set; }
        

    }
}
