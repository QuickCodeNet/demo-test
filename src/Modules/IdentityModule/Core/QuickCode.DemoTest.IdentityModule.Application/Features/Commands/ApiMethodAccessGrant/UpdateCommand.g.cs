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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.ApiMethodAccessGrant;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.ApiMethodAccessGrant
{
    public class UpdateApiMethodAccessGrantCommand : IRequest<Response<bool>>
    {
        public string PermissionGroupName { get; set; }
        public string ApiMethodDefinitionKey { get; set; }
        public ApiMethodAccessGrantDto request { get; set; }

        public UpdateApiMethodAccessGrantCommand(string permissionGroupName, string apiMethodDefinitionKey, ApiMethodAccessGrantDto request)
        {
            this.request = request;
            this.PermissionGroupName = permissionGroupName;
            this.ApiMethodDefinitionKey = apiMethodDefinitionKey;
        }

        public class UpdateApiMethodAccessGrantHandler : IRequestHandler<UpdateApiMethodAccessGrantCommand, Response<bool>>
        {
            private readonly ILogger<UpdateApiMethodAccessGrantHandler> _logger;
            private readonly IApiMethodAccessGrantRepository _repository;
            public UpdateApiMethodAccessGrantHandler(ILogger<UpdateApiMethodAccessGrantHandler> logger, IApiMethodAccessGrantRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdateApiMethodAccessGrantCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.PermissionGroupName, request.ApiMethodDefinitionKey);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}