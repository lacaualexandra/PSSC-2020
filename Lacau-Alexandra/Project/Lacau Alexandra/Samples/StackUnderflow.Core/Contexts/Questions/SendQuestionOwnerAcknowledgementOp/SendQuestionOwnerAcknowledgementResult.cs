using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.SendQuestionOwnerAcknowledgementOp
{
    [AsChoice]
    public static partial class SendQuestionOwnerAcknowledgementResult
    {
        public interface ISendQuestionOwnerAcknowledgementResult { }

        public class AcknowledgementSent : ISendQuestionOwnerAcknowledgementResult
        {
            public AcknowledgementSent(int questionId, Guid questionOwnerId, InvitationLetter letter)
            {
                QuestionId = questionId;
                QuestionOwnerId = questionOwnerId;
                Letter = letter;
            }

            public InvitationLetter Letter { get; set; }
            public int QuestionId { get; }
            public Guid QuestionOwnerId { get; }
        }

        public class AcknowledgementNotSent : ISendQuestionOwnerAcknowledgementResult
        {
            public AcknowledgementNotSent(string message)
            {
                Message = message;
            }

            public string Message { get; }
        }
    }
}
