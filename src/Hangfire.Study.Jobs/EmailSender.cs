using System;
using Hangfire.Common;
using Microsoft.Extensions.Logging;

namespace Hangfire.Study.Jobs
{
    public class EmailSender : IEmailSender
    {
        private readonly IBackgroundJobClient _client;
        private readonly IRecurringJobManager _jobManager;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(IBackgroundJobClient client, IRecurringJobManager jobManager, ILogger<EmailSender> _logger)
        {
            _client = client;
            _jobManager = jobManager;
            this._logger = _logger;

            _jobManager.AddOrUpdate("Teste", Job.FromExpression(() => Lol()), Cron.Minutely());
        }

        public void Lol()
        {
            _logger.LogDebug("Executando o job aos {data}", DateTime.Now);
        }
    }

    public interface IEmailSender
    {
    }
}
