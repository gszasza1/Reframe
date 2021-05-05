using Microsoft.EntityFrameworkCore;
using Reframe.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reframe.Dal.Services
{
     public class NewService
    {
        public ReframeDbContext _dbContext{ get; }
        public NewService(ReframeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<NewsBox>> GetAllNewsAsync()
        {
            return await _dbContext.MoreNews.OrderBy(x => x.CreationTime).Select(z => new NewsBox()
            {
                CreationTime = z.CreationTime,
                Description = z.Description,
                Id = z.Id
            }).ToListAsync();
        }
    }
}
