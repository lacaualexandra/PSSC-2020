using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.PostQuestionOp
{
    [AsChoice]
    public static partial class PostQuestionResult
    {
        public interface IPostQuestionResult { }

        public class QuestionPosted : IPostQuestionResult
        {
            public int QuestionId { get; }
            public string Title { get; } 
            public string Body { get; } 
            public List<string> Tags { get; }  
            public int voteCounter { get;  }
            

            public QuestionPosted(int questionId, string title, string body, List<string> tags, int votecounter)
            {
                QuestionId = questionId;
                Title = title;
                Body = body;
                Tags = tags;
                voteCounter = votecounter;        
            }
        }

        public class QuestionNotPosted : IPostQuestionResult
        {
            public string Reason { get; }

            public QuestionNotPosted(string reason)
            {
                Reason = reason;
            }
        }

        public class QuestionValidationFailed : IPostQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; }

            public QuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}

