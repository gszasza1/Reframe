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
   public class PlaceService
    {
        public ReframeDbContext _dbContext { get; }
        public PlaceService(ReframeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Place> AddPlace(AddPlace post)
        {
            int parsed;
            if (int.TryParse(post.NumberOfDesk, out parsed) == false)
            {
                throw new InvalidOperationException("Rossz formázás");
            }
            if(await GetIsTakenAsync(post.Name))
            {
                throw new InvalidOperationException("Foglalt név");
            }
            var news = new Place()
            {
                CreationTime = DateTime.Now,
                Name = post.Name,
                NumberOfDesk = parsed
            };
            _dbContext.Places.Add(news);
            await _dbContext.SaveChangesAsync();
            return news;
        }
        public async Task<IEnumerable<PlaceListItem>> GetAllPlacesAsync()
        {
            return await _dbContext.Places
                .OrderBy(x => x.CreationTime)
                .Select(x => new PlaceListItem()
                {
                    CreationTime = x.CreationTime,
                    Name = x.Name,
                    Id = x.Id,
                    NumberOfDesk = x.NumberOfDesk
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<SelectItem>> GetAllPlacesSelectAsync()
        {
            return await _dbContext.Places
                .OrderBy(x => x.CreationTime)
                .Select(x => new SelectItem()
                {
                    Title = x.Name,
                    Id = x.Id,
                })
                .ToListAsync();
        }
        public async Task<bool> GetIsTakenAsync(string searchtext)
        {
            return await _dbContext.Places.AnyAsync(x => x.Name == searchtext);
        }

    }
}
