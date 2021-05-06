using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reframe.Dal.Dto;
using Reframe.Dal.Services;

namespace Reframe.Web.Pages.Auth
{
    public class ListSelfSubjectModel : PageModel
    {
        public IEnumerable<SubjectList> SubjectList { get; set; }
        public async Task OnGetAsync([FromServices] SubjectService subjectService)
        {
            SubjectList = await subjectService.GetUserSubjects(int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
    }
}
