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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.Model;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.Model
{
    public class DeleteModelCommand : IRequest<Response<bool>>
    {
        public ModelDto request { get; set; }

        public DeleteModelCommand(ModelDto request)
        {
            this.request = request;
        }

        public class DeleteModelHandler : IRequestHandler<DeleteModelCommand, Response<bool>>
        {
            private readonly ILogger<DeleteModelHandler> _logger;
            private readonly IModelRepository _repository;
            public DeleteModelHandler(ILogger<DeleteModelHandler> logger, IModelRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}