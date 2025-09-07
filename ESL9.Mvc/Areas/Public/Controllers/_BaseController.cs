using Application.Interfaces.IServices;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Mvc.Controllers;
using Mvc.Models.Enum;

namespace Mvc.Areas.Public.Controllers
{
    public class _BaseController<T>(ICoreService coreService, ILogger<T> logger) : BaseController<T>(coreService, logger) where T : _BaseController<T>
    {
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));

        ILogger<T> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public const UserArea Area = UserArea.Public;
    }
}
