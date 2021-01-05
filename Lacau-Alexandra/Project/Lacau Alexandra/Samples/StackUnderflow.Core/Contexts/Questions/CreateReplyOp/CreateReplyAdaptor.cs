using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.DatabaseModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Questions.CreateReplyOp.CreateReplyResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateReplyOp
{
    public class CreateReplyAdaptor : Adapter<CreateReplyCmd, ICreateReplyResult, QuestionsWriteContext, QuestionsDependencies>
    {
        public override Task PostConditions(CreateReplyCmd cmd, ICreateReplyResult result, QuestionsWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ICreateReplyResult> Work(CreateReplyCmd cmd, QuestionsWriteContext state, QuestionsDependencies dependencies)
        {
            var workflow = from valid in cmd.TryValidate()
                           let t = AddReplyToQuestion(state, CreateReplyFromCmd(cmd))
                           select t;

            var result =  await workflow.Match(
                Succ: r => r,
                Fail: ex => new ReplyNotCreated(ex.Message)
                );

            return result;
        }

        private ICreateReplyResult AddReplyToQuestion(QuestionsWriteContext state, Reply reply)
        {
            if (state.Replies.Any(p => p.ReplyId.Equals(reply.ReplyId)))
                return new ReplyNotCreated("Reply was not created");

            if (state.Replies.All(p => p.ReplyId != reply.ReplyId))
                state.Replies.Add(reply);
            return new ReplyCreated(reply.ReplyId, reply.QuestionId, reply.AuthorUserId, reply.Body);
        }

        private Reply CreateReplyFromCmd(CreateReplyCmd cmd)
        {
            var reply = new Reply()
            {
                ReplyId = cmd.ReplyId,
                QuestionId = cmd.QuestionId,
                AuthorUserId = cmd.AuthorUserId,
                Body = cmd.Body,
            };
            return reply;
        }
    }
}
