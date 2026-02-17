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
    public class GetRefreshTokensForAspNetUsersDetailsQuery : IRequest<Response<GetRefreshTokensForAspNetUsersResponseDto>>
    {
        public string AspNetUsersId { get; set; }
        public int RefreshTokensId { get; set; }

        public GetRefreshTokensForAspNetUsersDetailsQuery(string aspNetUsersId, int refreshTokensId)
        {
            this.AspNetUsersId = aspNetUsersId;
            this.RefreshTokensId = refreshTokensId;
        }

        public class GetRefreshTokensForAspNetUsersDetailsHandler : IRequestHandler<GetRefreshTokensForAspNetUsersDetailsQuery, Response<GetRefreshTokensForAspNetUsersResponseDto>>
        {
            private readonly ILogger<GetRefreshTokensForAspNetUsersDetailsHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetRefreshTokensForAspNetUsersDetailsHandler(ILogger<GetRefreshTokensForAspNetUsersDetailsHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetRefreshTokensForAspNetUsersResponseDto>> Handle(GetRefreshTokensForAspNetUsersDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetRefreshTokensForAspNetUsersDetailsAsync(request.AspNetUsersId, request.RefreshTokensId);
                return returnValue.ToResponse();
            }
        }
    }
}