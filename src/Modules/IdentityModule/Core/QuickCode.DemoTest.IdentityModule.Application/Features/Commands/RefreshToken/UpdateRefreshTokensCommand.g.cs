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
    public class UpdateRefreshTokensCommand : IRequest<Response<int>>
    {
        public string RefreshTokensToken { get; set; }
        public UpdateRefreshTokensRequestDto UpdateRequest { get; set; }

        public UpdateRefreshTokensCommand(string refreshTokensToken, UpdateRefreshTokensRequestDto updateRequest)
        {
            this.RefreshTokensToken = refreshTokensToken;
            this.UpdateRequest = updateRequest;
        }

        public class UpdateRefreshTokensHandler : IRequestHandler<UpdateRefreshTokensCommand, Response<int>>
        {
            private readonly ILogger<UpdateRefreshTokensHandler> _logger;
            private readonly IRefreshTokenRepository _repository;
            public UpdateRefreshTokensHandler(ILogger<UpdateRefreshTokensHandler> logger, IRefreshTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(UpdateRefreshTokensCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.UpdateRefreshTokensAsync(request.RefreshTokensToken, request.UpdateRequest);
                return returnValue.ToResponse();
            }
        }
    }
}