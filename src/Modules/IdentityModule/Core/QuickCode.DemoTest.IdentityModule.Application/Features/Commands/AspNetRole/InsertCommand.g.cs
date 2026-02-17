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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.AspNetRole;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.AspNetRole
{
    public class InsertAspNetRoleCommand : IRequest<Response<AspNetRoleDto>>
    {
        public AspNetRoleDto request { get; set; }

        public InsertAspNetRoleCommand(AspNetRoleDto request)
        {
            this.request = request;
        }

        public class InsertAspNetRoleHandler : IRequestHandler<InsertAspNetRoleCommand, Response<AspNetRoleDto>>
        {
            private readonly ILogger<InsertAspNetRoleHandler> _logger;
            private readonly IAspNetRoleRepository _repository;
            public InsertAspNetRoleHandler(ILogger<InsertAspNetRoleHandler> logger, IAspNetRoleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AspNetRoleDto>> Handle(InsertAspNetRoleCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}