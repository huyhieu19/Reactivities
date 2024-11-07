using Microsoft.AspNetCore.Mvc;
using Reactivities.Dtos;
using Reactivities.Entity.Dtos;
using Reactivities.Services.Interface;

namespace Reactivities.API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpPost("paging")]
        public async Task<PagedResult<ActivityDto>> Get(PaginationBaseQuery dto)
        {
            return await _activityService.Get(dto);
        }
    }
}
