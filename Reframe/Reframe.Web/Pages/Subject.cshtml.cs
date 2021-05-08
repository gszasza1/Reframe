using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reframe.Dal.Dto;
using Reframe.Dal.Services;

namespace Reframe.Web.Pages
{
    public class SubjectModel : PageModel
    {
        public SpecificSubject SpecificSubject { get; set; }
        public async Task OnGetAsync(int id, [FromServices] SubjectService subjectService)
        {
            SpecificSubject = await subjectService.GetSpecSubjectByIdAsync(id);
        }
    }
}
