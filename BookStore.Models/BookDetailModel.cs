using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Models
{
   public class BookDetailModel
    {
        public int book_id { get; set; }
        public string book_name { get; set; }
        public string author_name { get; set; }
        public string publisher_name { get; set; }
        public int book_count { get; set; }
    }

    public class BookDetailInsertModel
    {
        public int book_id { get; set; }
        public string book_name { get; set; }
        public string author_name { get; set; }
        public string publisher_name { get; set; }
        public int book_count { get; set; }
    }
}
