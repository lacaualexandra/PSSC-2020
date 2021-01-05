using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguageOp
{
    [AsChoice]
    public static partial class CheckLanguageResult
    {
        public interface ICheckLanguageResult { }

        public class ValidationSucceeded : ICheckLanguageResult
        {
            public ValidationSucceeded(int replyId,string text)
            {
                ReplyId = replyId;
                Text = text;
            }
            public int ReplyId { get; set; }
            public string Text { get; }
        }

        public class ValidationFailed : ICheckLanguageResult
        {
            public ValidationFailed(string message)
            {
                Message = message;
            }

            public string Message { get; }
        }

        public class ManualReviewRequired : ICheckLanguageResult
        {
            public ManualReviewRequired(string text)
            {
                Text = text;
            }

            public string Text { get; }
        }
    }
}
