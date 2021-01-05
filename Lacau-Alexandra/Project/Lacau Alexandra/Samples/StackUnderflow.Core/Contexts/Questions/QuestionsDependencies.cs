using LanguageExt;
using StackUnderflow.Domain.Core.Contexts.Questions.SendQuestionOwnerAcknowledgementOp;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public class QuestionsDependencies
    {
        public Func<string> GenerateInvitationToken { get; set; }
        public Func<InvitationLetter, TryAsync<SendQuestionOwnerAcknowledgementResult.AcknowledgementSent>> SendInvitationEmail { get; set; }
    }
}
