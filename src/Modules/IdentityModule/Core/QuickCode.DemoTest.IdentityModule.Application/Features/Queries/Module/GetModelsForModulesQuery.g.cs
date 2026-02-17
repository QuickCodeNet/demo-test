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
    public class GetModelsForModulesQuery : IRequest<Response<List<GetModelsForModulesResponseDto>>>
    {
        public string ModulesName { get; set; }

        public GetModelsForModulesQuery(string modulesName)
        {
            this.ModulesName = modulesName;
        }

        public class GetModelsForModulesHandler : IRequestHandler<GetModelsForModulesQuery, Response<List<GetModelsForModulesResponseDto>>>
        {
            private readonly ILogger<GetModelsForModulesHandler> _logger;
            private readonly IModuleRepository _repository;
            public GetModelsForModulesHandler(ILogger<GetModelsForModulesHandler> logger, IModuleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetModelsForModulesResponseDto>>> Handle(GetModelsForModulesQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetModelsForModulesAsync(request.ModulesName);
                return returnValue.ToResponse();
            }
        }
    }
}