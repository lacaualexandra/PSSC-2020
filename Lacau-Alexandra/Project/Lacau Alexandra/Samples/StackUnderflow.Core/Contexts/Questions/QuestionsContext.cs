using Access.Primitives.IO;
using System;
using System.Collections.Generic;
using System.Text;
using static PortExt;
using static StackUnderflow.Domain.Core.Contexts.Questions.PostQuestionOp.PostQuestionResult;
using StackUnderflow.Domain.Core.Contexts.Questions.PostQuestionOp;
using static StackUnderflow.Domain.Core.Contexts.Questions.CreateReplyOp.CreateReplyResult;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateReplyOp;
using static StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguageOp.CheckLanguageResult;
using StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguageOp;
using static StackUnderflow.Domain.Core.Contexts.Questions.SendQuestionOwnerAcknowledgementOp.SendQuestionOwnerAcknowledgementResult;
using StackUnderflow.Domain.Core.Contexts.Questions.SendQuestionOwnerAcknowledgementOp;
using static StackUnderflow.Domain.Core.Contexts.Questions.SendReplyAuthorAcknowledgementOp.SendReplyAuthorAcknowledgementResult;
using StackUnderflow.Domain.Core.Contexts.Questions.SendReplyAuthorAcknowledgementOp;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public static class QuestionsContext
    {
        public static Port<IPostQuestionResult> PostQuestion(PostQuestionCmd postQuestionCmd) =>
           NewPort<PostQuestionCmd, IPostQuestionResult>(postQuestionCmd);
        public static Port<ICreateReplyResult> CreateReply(CreateReplyCmd createReplyCmd) =>
           NewPort<CreateReplyCmd, ICreateReplyResult>(createReplyCmd);

        public static Port<ICheckLanguageResult> CheckLanguage(CheckLanguageCmd checkLanguageCmd) =>
            NewPort<CheckLanguageCmd, ICheckLanguageResult>(checkLanguageCmd);

        public static Port<ISendQuestionOwnerAcknowledgementResult> SendQuestionOwnerAcknowledgement(SendQuestionOwnerAcknowledgementCmd cmd) =>
            NewPort<SendQuestionOwnerAcknowledgementCmd, ISendQuestionOwnerAcknowledgementResult>(cmd);

        public static Port<ISendReplyAuthorAcknowledgementResult> SendReplyAuthorAcknowledgement(SendReplyAuthorAcknowledgementCmd cmd) =>
           NewPort<SendReplyAuthorAcknowledgementCmd, ISendReplyAuthorAcknowledgementResult>(cmd);
    }
}
