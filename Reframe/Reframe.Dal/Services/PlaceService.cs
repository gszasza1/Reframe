using System;
using System.Collections.Generic;
using System.Text;

namespace Reframe.Dal.Services
{
   public class PlaceService
    {
        public ReframeDbContext _dbContext { get; }
        public PlaceService(ReframeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
