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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.PortalMenu;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.PortalMenu
{
    public class DeletePortalMenuCommand : IRequest<Response<bool>>
    {
        public PortalMenuDto request { get; set; }

        public DeletePortalMenuCommand(PortalMenuDto request)
        {
            this.request = request;
        }

        public class DeletePortalMenuHandler : IRequestHandler<DeletePortalMenuCommand, Response<bool>>
        {
            private readonly ILogger<DeletePortalMenuHandler> _logger;
            private readonly IPortalMenuRepository _repository;
            public DeletePortalMenuHandler(ILogger<DeletePortalMenuHandler> logger, IPortalMenuRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeletePortalMenuCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}