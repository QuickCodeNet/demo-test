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
    public class ExistsPortalPageDefinitionsWithModelNameQuery : IRequest<Response<bool>>
    {
        public string PortalPageDefinitionsModelName { get; set; }

        public ExistsPortalPageDefinitionsWithModelNameQuery(string portalPageDefinitionsModelName)
        {
            this.PortalPageDefinitionsModelName = portalPageDefinitionsModelName;
        }

        public class ExistsPortalPageDefinitionsWithModelNameHandler : IRequestHandler<ExistsPortalPageDefinitionsWithModelNameQuery, Response<bool>>
        {
            private readonly ILogger<ExistsPortalPageDefinitionsWithModelNameHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public ExistsPortalPageDefinitionsWithModelNameHandler(ILogger<ExistsPortalPageDefinitionsWithModelNameHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(ExistsPortalPageDefinitionsWithModelNameQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ExistsPortalPageDefinitionsWithModelNameAsync(request.PortalPageDefinitionsModelName);
                return returnValue.ToResponse();
            }
        }
    }
}