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
    public class TotalCountRefreshTokenQuery : IRequest<Response<int>>
    {
        public TotalCountRefreshTokenQuery()
        {
        }

        public class TotalCountRefreshTokenHandler : IRequestHandler<TotalCountRefreshTokenQuery, Response<int>>
        {
            private readonly ILogger<TotalCountRefreshTokenHandler> _logger;
            private readonly IRefreshTokenRepository _repository;
            public TotalCountRefreshTokenHandler(ILogger<TotalCountRefreshTokenHandler> logger, IRefreshTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountRefreshTokenQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}