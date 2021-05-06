using Microsoft.EntityFrameworkCore;
using Reframe.Dal.Dto;
using Reframe.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Reframe.Dal.Services
{
   public class SubjectService
    {
        public ReframeDbContext _dbContext { get; }
        public SubjectService(ReframeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<SubjectList>> GetSubjects(SubjectSearch specification = null)
        {
            specification ??= new SubjectSearch();

            IQueryable<Subject> query = _dbContext.Subjects;

            // Szűrés megvalósítása
            if (specification.Credit != null && int.TryParse(specification.Credit, out int n))
                query = query.Where(b => b.Credit == n);

            if (!string.IsNullOrWhiteSpace(specification?.SearchText))
                query = query.Where(b => b.Description.Contains(specification.SearchText) || b.Title.Contains(specification.SearchText));

            // Rendezés
            if (specification.IsAsc)
            {
                query = query.OrderBy(b => b.Title);
            }
            else
            {
                query = query.OrderByDescending(b => b.Title);
            }

            return  await query.Select(x => new SubjectList() {
                Credit = x.Credit,
                Description = x.Description,
                Title=x.Title
            }).ToListAsync();
        }
        public async Task AddSubject(AddSubject addSubject)
        {
            var newSubject = new Subject()
            {
                UserId = addSubject.UserId,
                Title = addSubject.Title,
                Description = addSubject.Description,
                Credit = addSubject.Credit
            };
            _dbContext.Add(newSubject);
           await _dbContext.SaveChangesAsync();
           return;

        }
    }
}
