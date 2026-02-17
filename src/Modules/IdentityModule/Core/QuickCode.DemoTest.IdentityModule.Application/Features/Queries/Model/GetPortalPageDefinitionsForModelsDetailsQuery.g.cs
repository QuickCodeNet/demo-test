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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.Model;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.Model
{
    public class GetPortalPageDefinitionsForModelsDetailsQuery : IRequest<Response<GetPortalPageDefinitionsForModelsResponseDto>>
    {
        public string ModelsName { get; set; }
        public string PortalPageDefinitionsKey { get; set; }

        public GetPortalPageDefinitionsForModelsDetailsQuery(string modelsName, string portalPageDefinitionsKey)
        {
            this.ModelsName = modelsName;
            this.PortalPageDefinitionsKey = portalPageDefinitionsKey;
        }

        public class GetPortalPageDefinitionsForModelsDetailsHandler : IRequestHandler<GetPortalPageDefinitionsForModelsDetailsQuery, Response<GetPortalPageDefinitionsForModelsResponseDto>>
        {
            private readonly ILogger<GetPortalPageDefinitionsForModelsDetailsHandler> _logger;
            private readonly IModelRepository _repository;
            public GetPortalPageDefinitionsForModelsDetailsHandler(ILogger<GetPortalPageDefinitionsForModelsDetailsHandler> logger, IModelRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetPortalPageDefinitionsForModelsResponseDto>> Handle(GetPortalPageDefinitionsForModelsDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageDefinitionsForModelsDetailsAsync(request.ModelsName, request.PortalPageDefinitionsKey);
                return returnValue.ToResponse();
            }
        }
    }
}