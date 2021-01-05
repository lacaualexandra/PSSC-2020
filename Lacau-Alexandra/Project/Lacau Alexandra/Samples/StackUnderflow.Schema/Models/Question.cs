using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StackUnderflow.DatabaseModel.Models
{
    [Table("Question")]
    public class Question
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<string> Tags { get; set; }
        public int Votes { get; set; }
    }
}
