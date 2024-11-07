using Reactivities.Dtos;
using Reactivities.Entity.Dtos;

namespace Reactivities.Services.Interface
{
    public interface IActivityService
    {
        Task<PagedResult<ActivityDto>> Get(PaginationBaseQuery dto);
    }
}
