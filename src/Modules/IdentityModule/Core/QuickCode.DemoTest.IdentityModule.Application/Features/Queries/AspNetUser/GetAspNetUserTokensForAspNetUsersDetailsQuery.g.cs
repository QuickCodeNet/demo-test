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
    public class GetAspNetUserTokensForAspNetUsersDetailsQuery : IRequest<Response<GetAspNetUserTokensForAspNetUsersResponseDto>>
    {
        public string AspNetUsersId { get; set; }
        public string AspNetUserTokensUserId { get; set; }

        public GetAspNetUserTokensForAspNetUsersDetailsQuery(string aspNetUsersId, string aspNetUserTokensUserId)
        {
            this.AspNetUsersId = aspNetUsersId;
            this.AspNetUserTokensUserId = aspNetUserTokensUserId;
        }

        public class GetAspNetUserTokensForAspNetUsersDetailsHandler : IRequestHandler<GetAspNetUserTokensForAspNetUsersDetailsQuery, Response<GetAspNetUserTokensForAspNetUsersResponseDto>>
        {
            private readonly ILogger<GetAspNetUserTokensForAspNetUsersDetailsHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetAspNetUserTokensForAspNetUsersDetailsHandler(ILogger<GetAspNetUserTokensForAspNetUsersDetailsHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetAspNetUserTokensForAspNetUsersResponseDto>> Handle(GetAspNetUserTokensForAspNetUsersDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetAspNetUserTokensForAspNetUsersDetailsAsync(request.AspNetUsersId, request.AspNetUserTokensUserId);
                return returnValue.ToResponse();
            }
        }
    }
}