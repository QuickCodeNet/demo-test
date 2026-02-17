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
    public class DeletePortalPageDefinitionsWithModuleNameCommand : IRequest<Response<int>>
    {
        public string PortalPageDefinitionsModuleName { get; set; }

        public DeletePortalPageDefinitionsWithModuleNameCommand(string portalPageDefinitionsModuleName)
        {
            this.PortalPageDefinitionsModuleName = portalPageDefinitionsModuleName;
        }

        public class DeletePortalPageDefinitionsWithModuleNameHandler : IRequestHandler<DeletePortalPageDefinitionsWithModuleNameCommand, Response<int>>
        {
            private readonly ILogger<DeletePortalPageDefinitionsWithModuleNameHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public DeletePortalPageDefinitionsWithModuleNameHandler(ILogger<DeletePortalPageDefinitionsWithModuleNameHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(DeletePortalPageDefinitionsWithModuleNameCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.DeletePortalPageDefinitionsWithModuleNameAsync(request.PortalPageDefinitionsModuleName);
                return returnValue.ToResponse();
            }
        }
    }
}