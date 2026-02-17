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
    public class TotalCountKafkaEventQuery : IRequest<Response<int>>
    {
        public TotalCountKafkaEventQuery()
        {
        }

        public class TotalCountKafkaEventHandler : IRequestHandler<TotalCountKafkaEventQuery, Response<int>>
        {
            private readonly ILogger<TotalCountKafkaEventHandler> _logger;
            private readonly IKafkaEventRepository _repository;
            public TotalCountKafkaEventHandler(ILogger<TotalCountKafkaEventHandler> logger, IKafkaEventRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountKafkaEventQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}