using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguageOp
{
    public class CheckLanguageCmd
    {
        public CheckLanguageCmd()
        {

        }

        public CheckLanguageCmd(int replyId, string text)
        {
            replyId = ReplyId;
            Text = text;
        }

        [Required]
        public int ReplyId { get; set; }
        [Required]
        public string Text { get; }
    }
}
