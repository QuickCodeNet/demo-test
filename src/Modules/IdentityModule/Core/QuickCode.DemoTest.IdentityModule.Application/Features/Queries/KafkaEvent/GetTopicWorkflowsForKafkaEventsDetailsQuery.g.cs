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
    public class GetTopicWorkflowsForKafkaEventsDetailsQuery : IRequest<Response<GetTopicWorkflowsForKafkaEventsResponseDto>>
    {
        public string KafkaEventsTopicName { get; set; }
        public int TopicWorkflowsId { get; set; }

        public GetTopicWorkflowsForKafkaEventsDetailsQuery(string kafkaEventsTopicName, int topicWorkflowsId)
        {
            this.KafkaEventsTopicName = kafkaEventsTopicName;
            this.TopicWorkflowsId = topicWorkflowsId;
        }

        public class GetTopicWorkflowsForKafkaEventsDetailsHandler : IRequestHandler<GetTopicWorkflowsForKafkaEventsDetailsQuery, Response<GetTopicWorkflowsForKafkaEventsResponseDto>>
        {
            private readonly ILogger<GetTopicWorkflowsForKafkaEventsDetailsHandler> _logger;
            private readonly IKafkaEventRepository _repository;
            public GetTopicWorkflowsForKafkaEventsDetailsHandler(ILogger<GetTopicWorkflowsForKafkaEventsDetailsHandler> logger, IKafkaEventRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetTopicWorkflowsForKafkaEventsResponseDto>> Handle(GetTopicWorkflowsForKafkaEventsDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetTopicWorkflowsForKafkaEventsDetailsAsync(request.KafkaEventsTopicName, request.TopicWorkflowsId);
                return returnValue.ToResponse();
            }
        }
    }
}