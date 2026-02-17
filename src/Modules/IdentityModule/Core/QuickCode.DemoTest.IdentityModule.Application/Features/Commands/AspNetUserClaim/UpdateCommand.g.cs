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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.AspNetUserClaim;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.AspNetUserClaim
{
    public class UpdateAspNetUserClaimCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }
        public AspNetUserClaimDto request { get; set; }

        public UpdateAspNetUserClaimCommand(int id, AspNetUserClaimDto request)
        {
            this.request = request;
            this.Id = id;
        }

        public class UpdateAspNetUserClaimHandler : IRequestHandler<UpdateAspNetUserClaimCommand, Response<bool>>
        {
            private readonly ILogger<UpdateAspNetUserClaimHandler> _logger;
            private readonly IAspNetUserClaimRepository _repository;
            public UpdateAspNetUserClaimHandler(ILogger<UpdateAspNetUserClaimHandler> logger, IAspNetUserClaimRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdateAspNetUserClaimCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.Id);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}