using System;
using System.Linq;
using QuickCode.DemoTest.Common.Mediator;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.IdentityModule.Domain.Entities;
using QuickCode.DemoTest.IdentityModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.IdentityModule.Application.Dtos.ApiMethodDefinition;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.ApiMethodDefinition
{
    public class GetKafkaEventsForApiMethodDefinitionsDetailsQuery : IRequest<Response<GetKafkaEventsForApiMethodDefinitionsResponseDto>>
    {
        public string ApiMethodDefinitionsKey { get; set; }
        public string KafkaEventsTopicName { get; set; }

        public GetKafkaEventsForApiMethodDefinitionsDetailsQuery(string apiMethodDefinitionsKey, string kafkaEventsTopicName)
        {
            this.ApiMethodDefinitionsKey = apiMethodDefinitionsKey;
            this.KafkaEventsTopicName = kafkaEventsTopicName;
        }

        public class GetKafkaEventsForApiMethodDefinitionsDetailsHandler : IRequestHandler<GetKafkaEventsForApiMethodDefinitionsDetailsQuery, Response<GetKafkaEventsForApiMethodDefinitionsResponseDto>>
        {
            private readonly ILogger<GetKafkaEventsForApiMethodDefinitionsDetailsHandler> _logger;
            private readonly IApiMethodDefinitionRepository _repository;
            public GetKafkaEventsForApiMethodDefinitionsDetailsHandler(ILogger<GetKafkaEventsForApiMethodDefinitionsDetailsHandler> logger, IApiMethodDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetKafkaEventsForApiMethodDefinitionsResponseDto>> Handle(GetKafkaEventsForApiMethodDefinitionsDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetKafkaEventsForApiMethodDefinitionsDetailsAsync(request.ApiMethodDefinitionsKey, request.KafkaEventsTopicName);
                return returnValue.ToResponse();
            }
        }
    }
}