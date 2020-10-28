using DomainQuestion.CreateQuestionWorkflow;
using DomainQuestion.CreateUserWorkflow;
using System;
using System.Collections.Generic;
using System.Linq;
using static DomainQuestion.CreateQuestionWorkflow.CreateQuestionResult;

namespace ApplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tags = new List<string>() {
               "C#",
               "VS2019"
           };

            var user = new CreateUserCommand("alexandra", "lacau", "lacaualexandra99@icloud.com");
            var userResult = CreateUser(user);

            var question = new CreateQuestionCommand("Add reference to a project", "Issue", tags, "How to add reference to a C# project in Visual Studio 2019?");
            var questionResult = CreateQuestion(question, (UserCreated)userResult);
   
            ((QuestionPublished)questionResult).VoteQuestion((UserCreated)userResult, true);
            ((QuestionPublished)questionResult).VoteQuestion((UserCreated)userResult, false);
            Console.WriteLine("The total number of votes for the question is:" + ((QuestionPublished)questionResult).Votes.ToString());

        }
        public static ICreateUser CreateUser(CreateUserCommand receivedRegistration)
        {
            if (string.IsNullOrWhiteSpace(receivedRegistration.FirstName) ||
                string.IsNullOrWhiteSpace(receivedRegistration.LastName) ||
                string.IsNullOrWhiteSpace(receivedRegistration.Email))
            {
                IEnumerable<string> errors = new List<string>() {
                      "First name empty",
                      "Last name empty",
                      "Email address empty"
                    };
                return new UserNotValidated(errors);
            }

            return new UserCreated(receivedRegistration, Guid.NewGuid());
        }
        public static ICreateQuestionResult CreateQuestion(CreateQuestionCommand receivedQuestion, UserCreated fromUser)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(receivedQuestion.Title) || string.IsNullOrWhiteSpace(receivedQuestion.Question))
            {
                errors.Add("Empty title");
                errors.Add("Empty question");
            }

            if (receivedQuestion.Tags.Count() < 1 || receivedQuestion.Tags.Count() > 3)
            {
                errors.Add("Incorrect number of tags");
            }

            if (errors.Count() > 0)
            {
                return new QuestionValidationFailed(errors.AsEnumerable());
            }

            return new QuestionPublished(receivedQuestion, Guid.NewGuid(), fromUser);
        }
    }
}