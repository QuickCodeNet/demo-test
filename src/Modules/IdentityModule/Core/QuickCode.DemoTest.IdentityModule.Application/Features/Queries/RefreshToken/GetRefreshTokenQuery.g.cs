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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.RefreshToken;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.RefreshToken
{
    public class GetRefreshTokenQuery : IRequest<Response<GetRefreshTokenResponseDto>>
    {
        public string RefreshTokensToken { get; set; }

        public GetRefreshTokenQuery(string refreshTokensToken)
        {
            this.RefreshTokensToken = refreshTokensToken;
        }

        public class GetRefreshTokenHandler : IRequestHandler<GetRefreshTokenQuery, Response<GetRefreshTokenResponseDto>>
        {
            private readonly ILogger<GetRefreshTokenHandler> _logger;
            private readonly IRefreshTokenRepository _repository;
            public GetRefreshTokenHandler(ILogger<GetRefreshTokenHandler> logger, IRefreshTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetRefreshTokenResponseDto>> Handle(GetRefreshTokenQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetRefreshTokenAsync(request.RefreshTokensToken);
                return returnValue.ToResponse();
            }
        }
    }
}