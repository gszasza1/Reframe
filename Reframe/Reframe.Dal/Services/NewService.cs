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
        public async Task<NewsPage> GetSpecificNewsAsync(int id)
        {
            var news = await _dbContext.MoreNews.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(true);
            return new NewsPage()
            {
                CreationTime = news.CreationTime,
                Body = news.Body,
                Id = news.Id
            };
        }
        public void AddNews(PostNews postNews)
        {
            var news = new News()
            {
                CreationTime = DateTime.Now,
                Body = postNews.Body,
                Description = postNews.Description
            };
            _dbContext.MoreNews.Add(news);
            _dbContext.SaveChangesAsync();
            return;
        }
    }
}
