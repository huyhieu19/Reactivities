using Reactivities.Dtos;
using Reactivities.Entity;
using Reactivities.Entity.Dtos;
using Reactivities.Repository.Interface;
using Reactivities.Services.Interface;

namespace Reactivities.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _repository;

        public ActivityService(IActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<ActivityDto>> Get(PaginationBaseQuery dto)
        {
            List<string> searchColumns =
                [nameof(Activity.Title),
                nameof(Activity.Description),
                nameof(Activity.Category),
                nameof(Activity.City),
                nameof(Activity.Venue)];

            PaginationParameter paginationParameter = new PaginationParameter()
            {
                PageNumber = dto.PageNumber,
                PageSize = dto.PageSize,
                Filters = dto.Filters,
                SearchColumns = searchColumns,
                SearchKeyword = dto.SearchKeyword,
                Sorter = dto.Sorter
            };

            Func<Activity, ActivityDto> mapper = MapToDto;

            return await _repository.GetPagedAsync(paginationParameter, mapper);
        }


        public static ActivityDto MapToDto(Activity x)
        {
            return new ActivityDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Category = x.Category,
                DateTime = x.DateTime,
                City = x.City,
                Venue = x.Venue,
                IsCancelled = x.IsCancelled,
                IsDeleted = x.IsDeleted,
                TimeDeleted = x.TimeDeleted
            };
        }
    }
}
