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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.AspNetUser;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.AspNetUser
{
    public class GetRefreshTokensForAspNetUsersQuery : IRequest<Response<List<GetRefreshTokensForAspNetUsersResponseDto>>>
    {
        public string AspNetUsersId { get; set; }

        public GetRefreshTokensForAspNetUsersQuery(string aspNetUsersId)
        {
            this.AspNetUsersId = aspNetUsersId;
        }

        public class GetRefreshTokensForAspNetUsersHandler : IRequestHandler<GetRefreshTokensForAspNetUsersQuery, Response<List<GetRefreshTokensForAspNetUsersResponseDto>>>
        {
            private readonly ILogger<GetRefreshTokensForAspNetUsersHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetRefreshTokensForAspNetUsersHandler(ILogger<GetRefreshTokensForAspNetUsersHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetRefreshTokensForAspNetUsersResponseDto>>> Handle(GetRefreshTokensForAspNetUsersQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetRefreshTokensForAspNetUsersAsync(request.AspNetUsersId);
                return returnValue.ToResponse();
            }
        }
    }
}