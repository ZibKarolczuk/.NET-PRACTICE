using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MeterReaderWeb.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MeterReaderClient
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public readonly IConfiguration _config;
        private MeterReadingService.MeterReadingServiceClient _client = null;

        protected MeterReadingService.MeterReadingServiceClient Client {
            get {
                if (_client == null)
                {
                    var channel = Grpc.Net.Client.GrpcChannel.ForAddress(_config["ServiceLServiceUrl"]);
                    _client = new MeterReadingService.MeterReadingServiceClient(channel)
                };

                return _client;
            }
        }

        public Worker(ILogger<Worker> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var customerId = _config.GetValue<int>("Service:CustomerId");

                //var pkt = new ReadingPacket();
                //var result = await Client.AddReadingAsync(pkt);

                await Task.Delay(_config.GetValue<int>("Service:DelayInterval"), stoppingToken);
            }
        }
    }
}
