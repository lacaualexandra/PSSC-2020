using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Questions.SendReplyAuthorAcknowledgementOp.SendReplyAuthorAcknowledgementResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions.SendReplyAuthorAcknowledgementOp
{
    public class SendReplyAuthorAcknowledgementAdaptor : Adapter<SendReplyAuthorAcknowledgementCmd, ISendReplyAuthorAcknowledgementResult, QuestionsWriteContext, QuestionsDependencies>
    {
        public override Task PostConditions(SendReplyAuthorAcknowledgementCmd cmd, ISendReplyAuthorAcknowledgementResult result, QuestionsWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ISendReplyAuthorAcknowledgementResult> Work(SendReplyAuthorAcknowledgementCmd cmd, QuestionsWriteContext state, QuestionsDependencies dependencies)
        {
            var workflow = from valid in cmd.TryValidate()
                           let t = SendReplyAck(state, SendReplyAuthorAcknowledgementFromCmd(cmd))
                           select t;

            var result = await workflow.Match(
                Succ: r => r,
                Fail: ex => new AcknowledgementNotSent(ex.Message)
                );

            return result;
        }

        private ISendReplyAuthorAcknowledgementResult SendReplyAck(QuestionsWriteContext state, object v)
        {
            return new AcknowledgementSent(1, 2);
        }

        private object SendReplyAuthorAcknowledgementFromCmd(SendReplyAuthorAcknowledgementCmd cmd)
        {
            return new { };
        }
    }
}
