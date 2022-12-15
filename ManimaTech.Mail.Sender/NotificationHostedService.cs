using ManimaTech.Notification.Services.Message;
using Microsoft.Extensions.Hosting;

namespace ManimaTech.Notification.Sender
{
    public class NotificationHostedService : IHostedService, IDisposable
    {
        private readonly Runner _runner;

        public NotificationHostedService(Runner runner) 
        {
            _runner = runner;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _runner.Run();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Application stopping");
            return Task.CompletedTask;
        }

        public void Dispose()
        {

        }
    }
}
