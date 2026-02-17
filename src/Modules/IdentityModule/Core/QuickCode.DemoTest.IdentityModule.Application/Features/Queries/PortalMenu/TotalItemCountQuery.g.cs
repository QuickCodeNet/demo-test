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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.PortalMenu;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.PortalMenu
{
    public class TotalCountPortalMenuQuery : IRequest<Response<int>>
    {
        public TotalCountPortalMenuQuery()
        {
        }

        public class TotalCountPortalMenuHandler : IRequestHandler<TotalCountPortalMenuQuery, Response<int>>
        {
            private readonly ILogger<TotalCountPortalMenuHandler> _logger;
            private readonly IPortalMenuRepository _repository;
            public TotalCountPortalMenuHandler(ILogger<TotalCountPortalMenuHandler> logger, IPortalMenuRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountPortalMenuQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}