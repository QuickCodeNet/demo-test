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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.AspNetUserToken;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.AspNetUserToken
{
    public class UpdateAspNetUserTokenCommand : IRequest<Response<bool>>
    {
        public string UserId { get; set; }
        public AspNetUserTokenDto request { get; set; }

        public UpdateAspNetUserTokenCommand(string userId, AspNetUserTokenDto request)
        {
            this.request = request;
            this.UserId = userId;
        }

        public class UpdateAspNetUserTokenHandler : IRequestHandler<UpdateAspNetUserTokenCommand, Response<bool>>
        {
            private readonly ILogger<UpdateAspNetUserTokenHandler> _logger;
            private readonly IAspNetUserTokenRepository _repository;
            public UpdateAspNetUserTokenHandler(ILogger<UpdateAspNetUserTokenHandler> logger, IAspNetUserTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdateAspNetUserTokenCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.UserId);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}