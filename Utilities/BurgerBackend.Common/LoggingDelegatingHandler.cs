using Microsoft.Extensions.Logging;
using System.Net.Sockets;

namespace Common.Logger
{
    public class LoggingDelegatingHandler : DelegatingHandler
    {
        private readonly ILogger<LoggingDelegatingHandler> _logger;

        public LoggingDelegatingHandler(ILogger<LoggingDelegatingHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancelationToken)
        {
            try
            {
                _logger.LogInformation("Sending request to {Uri}", request.RequestUri);

                var response = await base.SendAsync(request, cancelationToken);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Received a successful response from {Uri}", response.RequestMessage.RequestUri);
                }
                else
                {
                    _logger.LogWarning("Received unsuccessful status code {statusCode} from {Uri}", (int)response.StatusCode, response.RequestMessage.RequestUri);
                }

                return response;
            }
            catch (HttpRequestException exception) when (exception.InnerException is SocketException se && se.SocketErrorCode == SocketError.ConnectionRefused)
            {
                string hostWithPort = request.RequestUri.IsDefaultPort
                    ? request.RequestUri.DnsSafeHost
                    : $"{request.RequestUri.DnsSafeHost}:{request.RequestUri.Port}";
                _logger.LogCritical(exception, "Unable to connect to {Host}. Please check the configuration", hostWithPort);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.BadGateway)
            {
                RequestMessage = request
            };
        }
    }
}