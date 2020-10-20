using System;
using System.Collections.Generic;
using System.Text;
using Question.Domain.CreateNewAnswerWorkflow;
using static Question.Domain.CreateNewAnswerWorkflow.CreateNewAnswerResult;
using CSharp.Choices;

namespace Test.App
{
    class Program_Answ
    {
        static void Main(string[] args)
        {
            DateTime date1 = new DateTime(2019, 10, 19);
            var cmd = new CreateNewAnswerCmd("You may recover some depth information using stereo-imaging and then recover the original size", "I've also checked", date1);
            var result = CreateNewAnswer(cmd);

            var createAnswerEvent = result.Match(ProcessAnswerPosted, ProcessAnswerNotPosted, ProcessInvalidAnswer);

            Console.ReadLine();
        }

        private static ICreateNewAnswerResult ProcessInvalidAnswer(AnswerValidationFailed validationErrors)
        {
            Console.WriteLine("Answer validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static ICreateNewAnswerResult ProcessAnswerNotPosted(AnswerNotPosted answerNotPosted)
        {
            Console.WriteLine($"Answer not posted: {answerNotPosted.Reason}");
            return answerNotPosted;
        }

        private static ICreateNewAnswerResult ProcessAnswerPosted(AnswerPosted new_answer)
        {
            Console.WriteLine($"Answer {new_answer.AnswerId}");
            Console.WriteLine($"Description {new_answer.Description}");
            return new_answer;
        }

        public static ICreateNewAnswerResult CreateNewAnswer(CreateNewAnswerCmd createAnswer)
        {
            if (string.IsNullOrWhiteSpace(createAnswer.DescriptionOfAnswer))
            {
                var errors = new List<string>() { "Invalid Description" };
                return new AnswerValidationFailed(errors);
            }

            if (createAnswer.Date_of_answer == null)
            {
                return new AnswerNotPosted("Missing date!Please give me a date!");
            }

            var answerId = Guid.NewGuid();
            var result = new AnswerPosted(answerId, createAnswer.DescriptionOfAnswer);

            return result;
        }
    }
}
