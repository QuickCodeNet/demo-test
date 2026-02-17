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
    public class GetTopicWorkflowsForKafkaEventsQuery : IRequest<Response<List<GetTopicWorkflowsForKafkaEventsResponseDto>>>
    {
        public string KafkaEventsTopicName { get; set; }

        public GetTopicWorkflowsForKafkaEventsQuery(string kafkaEventsTopicName)
        {
            this.KafkaEventsTopicName = kafkaEventsTopicName;
        }

        public class GetTopicWorkflowsForKafkaEventsHandler : IRequestHandler<GetTopicWorkflowsForKafkaEventsQuery, Response<List<GetTopicWorkflowsForKafkaEventsResponseDto>>>
        {
            private readonly ILogger<GetTopicWorkflowsForKafkaEventsHandler> _logger;
            private readonly IKafkaEventRepository _repository;
            public GetTopicWorkflowsForKafkaEventsHandler(ILogger<GetTopicWorkflowsForKafkaEventsHandler> logger, IKafkaEventRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetTopicWorkflowsForKafkaEventsResponseDto>>> Handle(GetTopicWorkflowsForKafkaEventsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetTopicWorkflowsForKafkaEventsAsync(request.KafkaEventsTopicName);
                return returnValue.ToResponse();
            }
        }
    }
}