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
    public class DeleteModelsWithModuleNameCommand : IRequest<Response<int>>
    {
        public string ModelsModuleName { get; set; }

        public DeleteModelsWithModuleNameCommand(string modelsModuleName)
        {
            this.ModelsModuleName = modelsModuleName;
        }

        public class DeleteModelsWithModuleNameHandler : IRequestHandler<DeleteModelsWithModuleNameCommand, Response<int>>
        {
            private readonly ILogger<DeleteModelsWithModuleNameHandler> _logger;
            private readonly IModelRepository _repository;
            public DeleteModelsWithModuleNameHandler(ILogger<DeleteModelsWithModuleNameHandler> logger, IModelRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(DeleteModelsWithModuleNameCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.DeleteModelsWithModuleNameAsync(request.ModelsModuleName);
                return returnValue.ToResponse();
            }
        }
    }
}