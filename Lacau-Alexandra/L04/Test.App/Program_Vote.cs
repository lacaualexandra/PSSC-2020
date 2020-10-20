using System;
using System.Collections.Generic;
using System.Text;

namespace Test.App
{
    class Program_Vote
    {
        static void Main(string[] args)
        {
            var cmd = new CreateNewVoteCmd(true, 1);
            var result = CreateNewVote(cmd);

            var createVoteEvent = result.Match(ProcessVoteGiven, ProcessVoteNotGiven, ProcessInvalidVote);

            Console.ReadLine();
        }

        private static ICreateVoteResult ProcessInvalidVote(VoteValidationFailed validationErrors)
        {
            Console.WriteLine("Vote validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static ICreateVoteResult ProcessVoteNotGiven(VoteNotGiven voteNotGiven)
        {
            Console.WriteLine($"Vote not given: {voteNotGiven.Reason}");
            return voteNotGiven;
        }

        private static ICreateVoteResult ProcessVoteGiven(VoteGiven new_vote)
        {
            Console.WriteLine($"Vote{new_vote.VoteId}");
            Console.WriteLine($"Number vote {new_vote.Nr_Vote}");
            return new_vote;
        }

        public static ICreateVoteResult CreateNewVote(CreateNewVoteCmd createVote)
        {
            if (createVote.GoodOrBad == null)
            {
                var errors = new List<string>() { "Invalid Description" };
                return new VoteValidationFailed(errors);
            }

            if (createVote.Nr_vote == null)
            {
                return new VoteNotGiven("Missing nr_vote!");
            }

            var voteId = Guid.NewGuid();
            var result = new VoteGiven(voteId, createVote.Nr_vote);

            return result;
        }
    }
}
