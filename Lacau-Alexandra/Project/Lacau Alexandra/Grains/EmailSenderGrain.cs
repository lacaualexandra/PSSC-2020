using GrainInterfaces;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Streams;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grains
{
    public class EmailSenderGrain : Orleans.Grain, IEmailSender
    {
        private readonly ILogger logger;

        public EmailSenderGrain(ILogger<HelloGrain> logger)
        {
            this.logger = logger;
        }

        async Task<string> IEmailSender.SendEmailAsync(string greeting)
        {
            IAsyncStream<string> stream = this.GetStreamProvider("SMSProvider").GetStream<string>(Guid.Empty, "chat");
            await stream.OnNextAsync($"{this.GetPrimaryKeyString()} - {greeting}");


            logger.LogInformation($"\n SayHello message received: greeting = '{greeting}'");
            return ($"\n Client said: '{greeting}', so HelloGrain says: Hello!");
        }
    }
}
