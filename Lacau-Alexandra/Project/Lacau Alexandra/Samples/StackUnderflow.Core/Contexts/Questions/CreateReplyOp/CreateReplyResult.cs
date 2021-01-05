using CSharp.Choices;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateReplyOp
{
    [AsChoice]
    public static partial class CreateReplyResult
    {
        public interface ICreateReplyResult { }

        public class ReplyCreated : ICreateReplyResult
        {
            public ReplyCreated(int replyId, int questionId, Guid authorUserId, string body)
            {
                ReplyId = replyId;
                QuestionId = questionId;
                AuthorUserId = authorUserId;
                Body = body;
            }

            public int ReplyId { get; }
            public int QuestionId { get; }
            public Guid AuthorUserId { get; }
            public string Body { get; }
        }

        public class ReplyNotCreated : ICreateReplyResult
        {
            public ReplyNotCreated(string message)
            {
                Message = message;
            }

            public string Message { get; }
        }
    }

    
}
