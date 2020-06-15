using DowntownRealty;
using Grpc.Core;
using GrpcRealtyService.Internals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GrpcRealtyService.Services
{
    public class GrpcRealtyService : DowntownRealty.DowntownRealty.DowntownRealtyBase
    {
        IRealtyService _realtyService;
        ILogger<GrpcRealtyService> _logger;

        public GrpcRealtyService(IRealtyService realtyService, ILogger<GrpcRealtyService> logger)
        {
            _logger = logger;
            _realtyService = realtyService;
        }

        public override Task<RealtyResponse> GetRealtyById(RealtyRequest request, ServerCallContext context)
        {
            _logger.LogWarning("grpc service called!");
            var result = _realtyService.GetRealtyById((int)request.Id);
            return Task.FromResult(new RealtyResponse
            {
                Message = result
            });
        }

        [Authorize]
        public override Task<RealtyListResponse> GetRealtyList(RealtyListRequest request, ServerCallContext context)
        {
            var result = _realtyService.GetRealtyList();

            var response = new RealtyListResponse();
            response.Items.AddRange(result);

            return Task.FromResult(response);
        }
    }
}
