using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.DatabaseModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguageOp.CheckLanguageResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguageOp
{
    public class CheckLanguageAdaptor : Adapter<CheckLanguageCmd, ICheckLanguageResult, QuestionsWriteContext, QuestionsDependencies>
    {
        public override Task PostConditions(CheckLanguageCmd cmd, ICheckLanguageResult result, QuestionsWriteContext state)
        {
            return Task.CompletedTask;
        }
        public async override Task<ICheckLanguageResult> Work(CheckLanguageCmd cmd, QuestionsWriteContext state, QuestionsDependencies dependencies)
        {
            var workflow = from valid in cmd.TryValidate()
                           let t = VerifyLanguage(state, VerifyAnswerFromCmd(cmd))
                           select t;

            var result = await workflow.Match(
                Succ: r => r,
                Fail: ex => new ValidationFailed(ex.Message)
                );

            return result;
        }

        private ICheckLanguageResult VerifyLanguage(QuestionsWriteContext state, CheckLanguageCmd v)
        {
            if (state.Replies.Any(p => p.ReplyId.Equals(v.ReplyId)) && v.Text.Length() < 10 && v.Text.Length() > 500)
               return new ValidationFailed("The reply is not valid!");
            else
               return new ValidationSucceeded(v.ReplyId, "For the reply with the id " + v.ReplyId + " the language was validated");
        }

        private CheckLanguageCmd VerifyAnswerFromCmd(CheckLanguageCmd cmd)
        {
            return cmd;
        }
    }
}
