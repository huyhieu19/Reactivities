using Reactivities.Database;
using Reactivities.Dtos;
using Reactivities.Entity;
using Reactivities.Entity.Dtos;
using Reactivities.Repository.Interface;
using static Reactivities.Repository.Interface.Repository.Interface.IBaseRepository;

namespace Reactivities.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IBaseRepository<DataContext> _repository;

        public ActivityRepository(IBaseRepository<DataContext> repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<ActivityDto>> GetPagedAsync(PaginationParameter parameter, Func<Activity, ActivityDto> converter)
        {
            return await _repository.GetPagination<Activity, ActivityDto>(parameter, converter: converter);
        }
    }
}
