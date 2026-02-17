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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.PortalPageAccessGrant;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.PortalPageAccessGrant
{
    public class GetPortalPageAccessGrantQuery : IRequest<Response<List<GetPortalPageAccessGrantResponseDto>>>
    {
        public string PortalPageAccessGrantsPermissionGroupName { get; set; }
        public string PortalPageAccessGrantsPortalPageDefinitionKey { get; set; }
        public PageActionType PortalPageAccessGrantsPageAction { get; set; }

        public GetPortalPageAccessGrantQuery(string portalPageAccessGrantsPermissionGroupName, string portalPageAccessGrantsPortalPageDefinitionKey, PageActionType portalPageAccessGrantsPageAction)
        {
            this.PortalPageAccessGrantsPermissionGroupName = portalPageAccessGrantsPermissionGroupName;
            this.PortalPageAccessGrantsPortalPageDefinitionKey = portalPageAccessGrantsPortalPageDefinitionKey;
            this.PortalPageAccessGrantsPageAction = portalPageAccessGrantsPageAction;
        }

        public class GetPortalPageAccessGrantHandler : IRequestHandler<GetPortalPageAccessGrantQuery, Response<List<GetPortalPageAccessGrantResponseDto>>>
        {
            private readonly ILogger<GetPortalPageAccessGrantHandler> _logger;
            private readonly IPortalPageAccessGrantRepository _repository;
            public GetPortalPageAccessGrantHandler(ILogger<GetPortalPageAccessGrantHandler> logger, IPortalPageAccessGrantRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetPortalPageAccessGrantResponseDto>>> Handle(GetPortalPageAccessGrantQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageAccessGrantAsync(request.PortalPageAccessGrantsPermissionGroupName, request.PortalPageAccessGrantsPortalPageDefinitionKey, request.PortalPageAccessGrantsPageAction);
                return returnValue.ToResponse();
            }
        }
    }
}