using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ganss.XSS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reframe.Dal.Dto;
using Reframe.Dal.Services;

namespace Reframe.Web.Pages.Auth
{
    public class AddSubjectModel : PageModel
    {
        private readonly SubjectService _subjectService;
        public AddSubjectModel(SubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        [BindProperty]
        public AddSubject AddSubject { get; set; }

        public async Task<IActionResult> OnPostAddSubject()
        {
            var sanitizer = new HtmlSanitizer();
           AddSubject.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
           await  _subjectService.AddSubject(AddSubject);
            return LocalRedirect("/");
        }
    }
}
