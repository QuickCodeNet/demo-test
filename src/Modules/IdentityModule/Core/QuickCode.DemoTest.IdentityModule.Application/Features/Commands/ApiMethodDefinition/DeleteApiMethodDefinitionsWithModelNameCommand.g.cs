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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.ApiMethodDefinition;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.ApiMethodDefinition
{
    public class DeleteApiMethodDefinitionsWithModelNameCommand : IRequest<Response<int>>
    {
        public string ApiMethodDefinitionsModelName { get; set; }

        public DeleteApiMethodDefinitionsWithModelNameCommand(string apiMethodDefinitionsModelName)
        {
            this.ApiMethodDefinitionsModelName = apiMethodDefinitionsModelName;
        }

        public class DeleteApiMethodDefinitionsWithModelNameHandler : IRequestHandler<DeleteApiMethodDefinitionsWithModelNameCommand, Response<int>>
        {
            private readonly ILogger<DeleteApiMethodDefinitionsWithModelNameHandler> _logger;
            private readonly IApiMethodDefinitionRepository _repository;
            public DeleteApiMethodDefinitionsWithModelNameHandler(ILogger<DeleteApiMethodDefinitionsWithModelNameHandler> logger, IApiMethodDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(DeleteApiMethodDefinitionsWithModelNameCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.DeleteApiMethodDefinitionsWithModelNameAsync(request.ApiMethodDefinitionsModelName);
                return returnValue.ToResponse();
            }
        }
    }
}