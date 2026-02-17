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
    public class DeletePortalPageDefinitionsWithModelNameCommand : IRequest<Response<int>>
    {
        public string PortalPageDefinitionsModelName { get; set; }

        public DeletePortalPageDefinitionsWithModelNameCommand(string portalPageDefinitionsModelName)
        {
            this.PortalPageDefinitionsModelName = portalPageDefinitionsModelName;
        }

        public class DeletePortalPageDefinitionsWithModelNameHandler : IRequestHandler<DeletePortalPageDefinitionsWithModelNameCommand, Response<int>>
        {
            private readonly ILogger<DeletePortalPageDefinitionsWithModelNameHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public DeletePortalPageDefinitionsWithModelNameHandler(ILogger<DeletePortalPageDefinitionsWithModelNameHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(DeletePortalPageDefinitionsWithModelNameCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.DeletePortalPageDefinitionsWithModelNameAsync(request.PortalPageDefinitionsModelName);
                return returnValue.ToResponse();
            }
        }
    }
}