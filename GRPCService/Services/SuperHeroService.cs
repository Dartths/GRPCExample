using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GRPCService.Endpoint
{
    public class SuperheroService : SuperHeroGetter.SuperHeroGetterBase
    {
        private readonly ILogger<SuperheroService> _logger;
        public SuperheroService(ILogger<SuperheroService> logger)
        {
            _logger = logger;
        }

        public override Task<AlterEgoReply> GetAlterEgo(AlterEgoRequest request, ServerCallContext context)
        {

            if (request.Name.ToLowerInvariant().Equals("superman"))
                return Task.FromResult(new AlterEgoReply
                {
                    Name = "Clark Kent",
                    Age = (int)((DateTimeOffset.Now - new DateTimeOffset(1938, 1, 1, 1, 1, 1, 1, TimeSpan.Zero)).TotalDays / 365),
                    Occupation = "Journalist"
                });

            return Task.FromResult(new AlterEgoReply());
        }

        public override Task<VillainReply> GetVillain(VillainRequest request, ServerCallContext context)
        {
            if (request.Name.ToLowerInvariant().Equals("superman"))
                return Task.FromResult(new VillainReply
            {
                Name = "Lex Luthor"
            });

            return Task.FromResult(new VillainReply());
        }
    }
}
