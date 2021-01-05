using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackUnderflow.DatabaseModel.Models
{
    [Table("Post")]
    public class Post
    {
 
 
        public int PostId { get; set; }
        public string Title { get; set; }
        public string PostText { get; set; }
        public Guid PostedBy { get; set; }
      

       
    }
}
