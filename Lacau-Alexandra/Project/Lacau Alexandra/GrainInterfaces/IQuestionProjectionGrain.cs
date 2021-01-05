using Orleans;
using StackUnderflow.DatabaseModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IQuestionProjectionGrain : IGrainWithStringKey
    {
        Task<(IEnumerable<Post>, IEnumerable<Reply>)> GetQuestionsAsync();
    }
}