using Microsoft.EntityFrameworkCore;
using Reframe.Dal.Dto;
using Reframe.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reframe.Dal.Services
{
    public class CourseService
    {
        public ReframeDbContext _dbContext { get; }
        public CourseService(ReframeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddCourse(AddCourse addCourse)
        {
            var newCourse = new Course()
            {
                UserId = addCourse.UserId,
                Title = addCourse.Title,
                Description = addCourse.Description,
                PlaceId = addCourse.PlaceId,
                SubjectId = addCourse.SubjectId,
                Time = addCourse.Time,
            };
            _dbContext.Courses.Add(newCourse);
            await _dbContext.SaveChangesAsync();
            return;
        }
        public async Task<IEnumerable<CourseListItem>> GetCourses()
        {
            return await _dbContext.Courses.OrderBy(x => x.CreationTime).Select(z => new CourseListItem()
            {
                CreationTime = z.CreationTime,
                Description = z.Description,
                Id = z.Id,
                Creator = z.User.Name,
                Time = z.Time,
                PlaceName = z.Place.Name,
                SubjectName = z.Subject.Title
            }).ToListAsync();
        }
    }
}
