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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.ColumnType;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.ColumnType
{
    public class DeleteItemColumnTypeCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }

        public DeleteItemColumnTypeCommand(int id)
        {
            this.Id = id;
        }

        public class DeleteItemColumnTypeHandler : IRequestHandler<DeleteItemColumnTypeCommand, Response<bool>>
        {
            private readonly ILogger<DeleteItemColumnTypeHandler> _logger;
            private readonly IColumnTypeRepository _repository;
            public DeleteItemColumnTypeHandler(ILogger<DeleteItemColumnTypeHandler> logger, IColumnTypeRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteItemColumnTypeCommand request, CancellationToken cancellationToken)
            {
                var deleteItem = await _repository.GetByPkAsync(request.Id);
                if (deleteItem.Code == 404)
                    return Response<bool>.NotFound();
                var returnValue = await _repository.DeleteAsync(deleteItem.Value);
                return returnValue.ToResponse();
            }
        }
    }
}