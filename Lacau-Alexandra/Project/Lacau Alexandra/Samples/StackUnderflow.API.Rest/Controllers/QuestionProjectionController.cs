using GrainInterfaces;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using StackUnderflow.DatabaseModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("questions-proj")]
    public class QuestionProjectionController : ControllerBase
    {
        private readonly IClusterClient clusterClient;
        public QuestionProjectionController(IClusterClient clusterC)
        {
            clusterClient = clusterC;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllQuestions()
        {
            //var questions= GetQuestionsFromDb();
            var questionsProjectionGrain = this.clusterClient.GetGrain<IQuestionProjectionGrain>("Id");
            var questions = await questionsProjectionGrain.GetQuestionsAsync();
            var questions2 = questions.Item1;
            var replies = questions.Item2;
            List<Object> all = (from x in questions2 select (Object)x).ToList();
            all.AddRange((from x in replies select (Object)x).ToList());

            return Ok(all);
        }
        /*
        private List<Post> GetQuestionsFromDb()
        {
            return new List<Post>
            {
                new Post
                {
                    PostId=1,
                    PostText="Question body",
                }
            };
        }
        */

    }
}