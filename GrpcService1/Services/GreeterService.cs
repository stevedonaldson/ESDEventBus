using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcService1
{
	public class GreeterService : Greeter.GreeterBase
	{
		private readonly ILogger<GreeterService> _logger;
		public GreeterService(ILogger<GreeterService> logger)
		{
			_logger = logger;
		}

		public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
		{
			//var httpContext = context.GetHttpContext();
			//var clientCertificate = httpContext.Connection.ClientCertificate;

			_logger.LogInformation("Saying hello to {Name}", request.Name);
			return Task.FromResult(new HelloReply
			{
				Message = "Hello " + request.Name
				//Message = "Hello " + request.Name + " from " + clientCertificate.Issuer
			});
		}
	}
}