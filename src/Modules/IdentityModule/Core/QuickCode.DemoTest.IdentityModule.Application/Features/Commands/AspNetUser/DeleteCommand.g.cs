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
    public class DeleteAspNetUserCommand : IRequest<Response<bool>>
    {
        public AspNetUserDto request { get; set; }

        public DeleteAspNetUserCommand(AspNetUserDto request)
        {
            this.request = request;
        }

        public class DeleteAspNetUserHandler : IRequestHandler<DeleteAspNetUserCommand, Response<bool>>
        {
            private readonly ILogger<DeleteAspNetUserHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public DeleteAspNetUserHandler(ILogger<DeleteAspNetUserHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteAspNetUserCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}