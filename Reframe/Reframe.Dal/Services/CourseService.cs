using System;
using System.Collections.Generic;
using System.Text;

namespace Reframe.Dal.Services
{
    public class CourseService
    {
        public ReframeDbContext _dbContext { get; }
        public CourseService(ReframeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
