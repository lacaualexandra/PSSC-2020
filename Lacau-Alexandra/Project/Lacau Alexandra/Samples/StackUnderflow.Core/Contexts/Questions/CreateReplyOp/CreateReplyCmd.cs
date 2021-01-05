using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateReplyOp
{
    public class CreateReplyCmd
    {
        public CreateReplyCmd()
        {

        }
        public CreateReplyCmd(int replyId,int questionId, Guid authorUserId, string body)
        {
            ReplyId = replyId;
            QuestionId = questionId;
            AuthorUserId = authorUserId;
            Body = body;
        }
        [Required]
        public int ReplyId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public Guid AuthorUserId { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Body { get; set; }
    }
}
