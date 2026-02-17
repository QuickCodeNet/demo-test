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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.ApiMethodAccessGrant;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.ApiMethodAccessGrant
{
    public class ClearApiMethodAccessGrantsCommand : IRequest<Response<int>>
    {
        public ClearApiMethodAccessGrantsCommand()
        {
        }

        public class ClearApiMethodAccessGrantsHandler : IRequestHandler<ClearApiMethodAccessGrantsCommand, Response<int>>
        {
            private readonly ILogger<ClearApiMethodAccessGrantsHandler> _logger;
            private readonly IApiMethodAccessGrantRepository _repository;
            public ClearApiMethodAccessGrantsHandler(ILogger<ClearApiMethodAccessGrantsHandler> logger, IApiMethodAccessGrantRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(ClearApiMethodAccessGrantsCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ClearApiMethodAccessGrantsAsync();
                return returnValue.ToResponse();
            }
        }
    }
}