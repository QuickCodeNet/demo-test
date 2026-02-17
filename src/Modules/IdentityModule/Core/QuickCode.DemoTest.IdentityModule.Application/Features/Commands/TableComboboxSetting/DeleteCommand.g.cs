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
using QuickCode.DemoTest.IdentityModule.Application.Dtos.TableComboboxSetting;
using QuickCode.DemoTest.IdentityModule.Domain.Enums;

namespace QuickCode.DemoTest.IdentityModule.Application.Features.TableComboboxSetting
{
    public class DeleteTableComboboxSettingCommand : IRequest<Response<bool>>
    {
        public TableComboboxSettingDto request { get; set; }

        public DeleteTableComboboxSettingCommand(TableComboboxSettingDto request)
        {
            this.request = request;
        }

        public class DeleteTableComboboxSettingHandler : IRequestHandler<DeleteTableComboboxSettingCommand, Response<bool>>
        {
            private readonly ILogger<DeleteTableComboboxSettingHandler> _logger;
            private readonly ITableComboboxSettingRepository _repository;
            public DeleteTableComboboxSettingHandler(ILogger<DeleteTableComboboxSettingHandler> logger, ITableComboboxSettingRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteTableComboboxSettingCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}