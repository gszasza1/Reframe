using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Reframe.Dal.Dto;
using Reframe.Dal.Entities;
using Reframe.Dal.Hubs;
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
        private IHubContext<CourseHub> _hubContext { get; set; }
        public CourseService(ReframeDbContext dbContext, IHubContext<CourseHub> hubcontext)
        {
            _dbContext = dbContext;
            _hubContext = hubcontext;
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
            var result = new CourseListItem()
            {
                CreationTime = newCourse.CreationTime,
                Title = newCourse.Title,
                Description = newCourse.Description,
                Id = newCourse.Id,
                Creator = (await _dbContext.Users.FirstOrDefaultAsync(x=>x.Id==newCourse.UserId)).Name,
                Time = newCourse.Time,
                PlaceName = ( await _dbContext.Places.FirstOrDefaultAsync(x => x.Id == newCourse.PlaceId) ).Name,
                SubjectName = ( await _dbContext.Subjects.FirstOrDefaultAsync(x => x.Id == newCourse.SubjectId) ).Title
            };
            await  _hubContext.Clients.All.SendAsync("AddCourse", result);
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
