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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.TopicWorkflow;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.TopicWorkflow
{
    public class InsertTopicWorkflowCommand : IRequest<Response<TopicWorkflowDto>>
    {
        public TopicWorkflowDto request { get; set; }

        public InsertTopicWorkflowCommand(TopicWorkflowDto request)
        {
            this.request = request;
        }

        public class InsertTopicWorkflowHandler : IRequestHandler<InsertTopicWorkflowCommand, Response<TopicWorkflowDto>>
        {
            private readonly ILogger<InsertTopicWorkflowHandler> _logger;
            private readonly ITopicWorkflowRepository _repository;
            public InsertTopicWorkflowHandler(ILogger<InsertTopicWorkflowHandler> logger, ITopicWorkflowRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<TopicWorkflowDto>> Handle(InsertTopicWorkflowCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}