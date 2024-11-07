using Reactivities.Dtos;
using Reactivities.Entity;
using Reactivities.Entity.Dtos;

namespace Reactivities.Repository.Interface
{
    public interface IActivityRepository
    {
        Task<PagedResult<ActivityDto>> GetPagedAsync(PaginationParameter parameter, Func<Activity, ActivityDto> converter);
    }
}
