using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Questions.SendQuestionOwnerAcknowledgementOp.SendQuestionOwnerAcknowledgementResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions.SendQuestionOwnerAcknowledgementOp
{
    public class SendQuestionOwnerAcknowledgementAdaptor : Adapter<SendQuestionOwnerAcknowledgementCmd, ISendQuestionOwnerAcknowledgementResult, QuestionsWriteContext, QuestionsDependencies>
    {
        public override Task PostConditions(SendQuestionOwnerAcknowledgementCmd cmd, ISendQuestionOwnerAcknowledgementResult result, QuestionsWriteContext state)
        {
            return Task.CompletedTask;
        }

        public override async Task<ISendQuestionOwnerAcknowledgementResult> Work(SendQuestionOwnerAcknowledgementCmd cmd, QuestionsWriteContext state, QuestionsDependencies dependencies)
        {
            var workflow = from valid in state.TryValidate()
                           let letter = GenerateInvitationLetter(cmd.QuestionOwnerId, cmd.Email)                    
                           from invitationAck in dependencies.SendInvitationEmail(letter)
                           select invitationAck;

            var result = await workflow.Match(
                Succ: r => r,
                Fail: ex => (ISendQuestionOwnerAcknowledgementResult) new AcknowledgementNotSent(ex.Message)
                );

            return result;
        }

        private InvitationLetter GenerateInvitationLetter(Guid userId, string email)
        {
            var link = $"https://stackunderflow/invite/QuestionPosted";
            var letter = @$"Dear {userId}Please click on {link}";
            return new InvitationLetter(email, letter, new Uri(link));
        }

        private object SendQuestionOwnerAcknowledgementFromCmd(SendQuestionOwnerAcknowledgementCmd cmd)
        {
            return new { };
        }
    }
}
