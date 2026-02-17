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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.Module;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.Module
{
    public class TotalCountModuleQuery : IRequest<Response<int>>
    {
        public TotalCountModuleQuery()
        {
        }

        public class TotalCountModuleHandler : IRequestHandler<TotalCountModuleQuery, Response<int>>
        {
            private readonly ILogger<TotalCountModuleHandler> _logger;
            private readonly IModuleRepository _repository;
            public TotalCountModuleHandler(ILogger<TotalCountModuleHandler> logger, IModuleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountModuleQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}