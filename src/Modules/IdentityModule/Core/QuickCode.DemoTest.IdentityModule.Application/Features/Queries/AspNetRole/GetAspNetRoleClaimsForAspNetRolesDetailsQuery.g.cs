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
    public class GetAspNetRoleClaimsForAspNetRolesDetailsQuery : IRequest<Response<GetAspNetRoleClaimsForAspNetRolesResponseDto>>
    {
        public string AspNetRolesId { get; set; }
        public int AspNetRoleClaimsId { get; set; }

        public GetAspNetRoleClaimsForAspNetRolesDetailsQuery(string aspNetRolesId, int aspNetRoleClaimsId)
        {
            this.AspNetRolesId = aspNetRolesId;
            this.AspNetRoleClaimsId = aspNetRoleClaimsId;
        }

        public class GetAspNetRoleClaimsForAspNetRolesDetailsHandler : IRequestHandler<GetAspNetRoleClaimsForAspNetRolesDetailsQuery, Response<GetAspNetRoleClaimsForAspNetRolesResponseDto>>
        {
            private readonly ILogger<GetAspNetRoleClaimsForAspNetRolesDetailsHandler> _logger;
            private readonly IAspNetRoleRepository _repository;
            public GetAspNetRoleClaimsForAspNetRolesDetailsHandler(ILogger<GetAspNetRoleClaimsForAspNetRolesDetailsHandler> logger, IAspNetRoleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetAspNetRoleClaimsForAspNetRolesResponseDto>> Handle(GetAspNetRoleClaimsForAspNetRolesDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetAspNetRoleClaimsForAspNetRolesDetailsAsync(request.AspNetRolesId, request.AspNetRoleClaimsId);
                return returnValue.ToResponse();
            }
        }
    }
}