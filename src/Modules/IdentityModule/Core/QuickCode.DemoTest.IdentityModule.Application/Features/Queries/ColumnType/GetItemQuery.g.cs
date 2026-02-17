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
    public class GetItemColumnTypeQuery : IRequest<Response<ColumnTypeDto>>
    {
        public int Id { get; set; }

        public GetItemColumnTypeQuery(int id)
        {
            this.Id = id;
        }

        public class GetItemColumnTypeHandler : IRequestHandler<GetItemColumnTypeQuery, Response<ColumnTypeDto>>
        {
            private readonly ILogger<GetItemColumnTypeHandler> _logger;
            private readonly IColumnTypeRepository _repository;
            public GetItemColumnTypeHandler(ILogger<GetItemColumnTypeHandler> logger, IColumnTypeRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<ColumnTypeDto>> Handle(GetItemColumnTypeQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.Id);
                return returnValue.ToResponse();
            }
        }
    }
}