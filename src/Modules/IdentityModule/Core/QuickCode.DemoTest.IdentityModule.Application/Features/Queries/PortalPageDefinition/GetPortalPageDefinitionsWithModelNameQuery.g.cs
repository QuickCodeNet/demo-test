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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.PortalPageDefinition;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.PortalPageDefinition
{
    public class GetPortalPageDefinitionsWithModelNameQuery : IRequest<Response<List<GetPortalPageDefinitionsWithModelNameResponseDto>>>
    {
        public string PortalPageDefinitionsModelName { get; set; }

        public GetPortalPageDefinitionsWithModelNameQuery(string portalPageDefinitionsModelName)
        {
            this.PortalPageDefinitionsModelName = portalPageDefinitionsModelName;
        }

        public class GetPortalPageDefinitionsWithModelNameHandler : IRequestHandler<GetPortalPageDefinitionsWithModelNameQuery, Response<List<GetPortalPageDefinitionsWithModelNameResponseDto>>>
        {
            private readonly ILogger<GetPortalPageDefinitionsWithModelNameHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public GetPortalPageDefinitionsWithModelNameHandler(ILogger<GetPortalPageDefinitionsWithModelNameHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetPortalPageDefinitionsWithModelNameResponseDto>>> Handle(GetPortalPageDefinitionsWithModelNameQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageDefinitionsWithModelNameAsync(request.PortalPageDefinitionsModelName);
                return returnValue.ToResponse();
            }
        }
    }
}