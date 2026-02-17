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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.AspNetUserLogin;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.AspNetUserLogin
{
    public class TotalCountAspNetUserLoginQuery : IRequest<Response<int>>
    {
        public TotalCountAspNetUserLoginQuery()
        {
        }

        public class TotalCountAspNetUserLoginHandler : IRequestHandler<TotalCountAspNetUserLoginQuery, Response<int>>
        {
            private readonly ILogger<TotalCountAspNetUserLoginHandler> _logger;
            private readonly IAspNetUserLoginRepository _repository;
            public TotalCountAspNetUserLoginHandler(ILogger<TotalCountAspNetUserLoginHandler> logger, IAspNetUserLoginRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountAspNetUserLoginQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}