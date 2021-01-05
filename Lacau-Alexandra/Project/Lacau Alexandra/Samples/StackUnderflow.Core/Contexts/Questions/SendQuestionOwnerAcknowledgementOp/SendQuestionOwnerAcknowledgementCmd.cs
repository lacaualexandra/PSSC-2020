using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.SendQuestionOwnerAcknowledgementOp
{
    public class SendQuestionOwnerAcknowledgementCmd
    {
        public SendQuestionOwnerAcknowledgementCmd()
        {

        }
        public SendQuestionOwnerAcknowledgementCmd(Guid questionOwnerId, string email)
        {
            QuestionOwnerId = questionOwnerId;
            Email = email;
        }

        public SendQuestionOwnerAcknowledgementCmd(int questionId, Guid questionOwnerId)
        {
            QuestionId = questionId;
            QuestionOwnerId = questionOwnerId;
        }

     
        public int QuestionId { get; }
        public Guid QuestionOwnerId { get; }
        public string Email { get; }
    }
}
