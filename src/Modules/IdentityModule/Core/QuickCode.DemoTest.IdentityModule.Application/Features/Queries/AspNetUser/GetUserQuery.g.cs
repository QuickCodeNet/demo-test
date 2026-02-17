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
    public class GetUserQuery : IRequest<Response<GetUserResponseDto>>
    {
        public string? AspNetUsersEmail { get; set; }

        public GetUserQuery(string? aspNetUsersEmail)
        {
            this.AspNetUsersEmail = aspNetUsersEmail;
        }

        public class GetUserHandler : IRequestHandler<GetUserQuery, Response<GetUserResponseDto>>
        {
            private readonly ILogger<GetUserHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetUserHandler(ILogger<GetUserHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetUserResponseDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetUserAsync(request.AspNetUsersEmail);
                return returnValue.ToResponse();
            }
        }
    }
}