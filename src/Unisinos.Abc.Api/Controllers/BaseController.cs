using Microsoft.AspNetCore.Mvc;
using Unisinos.Abc.Domain.Interfaces;

namespace Unisinos.Abc.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public BaseController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [NonAction]
        protected IActionResult GetResult()
        {
            if (_notificationService.HasNotificationError() == false)
            {
                return Ok(new
                {
                    success = true,
                    data = _notificationService.GetNotification().Select(x => x.Message).First()
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificationService.GetNotification().Select(x => x.Message).ToArray()
            });
        }
    }
}