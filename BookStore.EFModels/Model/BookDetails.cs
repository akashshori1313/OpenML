using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.EFModels.Model
{
  public class BookDetails
    {
        [Key]
        public int book_id{ get; set; }
        
        public string book_name { get; set; }
        
        public string author_name { get; set; }
        
        public string publisher_name { get; set; }
        public int book_count { get; set; }
    }
}
