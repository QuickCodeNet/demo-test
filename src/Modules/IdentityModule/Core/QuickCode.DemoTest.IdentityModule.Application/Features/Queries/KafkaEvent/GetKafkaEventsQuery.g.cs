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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.KafkaEvent;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.KafkaEvent
{
    public class GetKafkaEventsQuery : IRequest<Response<List<GetKafkaEventsResponseDto>>>
    {
        public GetKafkaEventsQuery()
        {
        }

        public class GetKafkaEventsHandler : IRequestHandler<GetKafkaEventsQuery, Response<List<GetKafkaEventsResponseDto>>>
        {
            private readonly ILogger<GetKafkaEventsHandler> _logger;
            private readonly IKafkaEventRepository _repository;
            public GetKafkaEventsHandler(ILogger<GetKafkaEventsHandler> logger, IKafkaEventRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetKafkaEventsResponseDto>>> Handle(GetKafkaEventsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetKafkaEventsAsync();
                return returnValue.ToResponse();
            }
        }
    }
}