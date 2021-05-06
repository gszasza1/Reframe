using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reframe.Dal.Dto;
using Reframe.Dal.Services;

namespace Reframe.Web.Pages.Auth
{
    public class AddCourseModel : PageModel
    {
        private readonly SubjectService _subjectService;
        private readonly CourseService _courseService;
        private readonly PlaceService _placeService;
        public AddCourseModel(SubjectService subjectService, CourseService courseService, PlaceService placeService)
        {
            _subjectService = subjectService;
            _courseService = courseService;
            _placeService = placeService;
        }
        [BindProperty]
        public AddCourse AddCourse { get; set; }

        public List<SelectListItem> AllPlaces { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> AllSubject { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnPostAddCourse()
        {
            if (ModelState.IsValid)
            {

                AddCourse.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                await _courseService.AddCourse(AddCourse);
                return LocalRedirect("/");
            }
            return Page();
        }
        public async Task OnGet()
        {
            ( await _placeService.GetAllPlacesSelectAsync() ).ToList().ForEach(x => {
                AllPlaces.Add(new SelectListItem() { Value = x.Id.ToString(), Text = x.Title });
            });
            ( await _subjectService.GetSubjectSelects() ).ToList().ForEach(x => {
                AllSubject.Add(new SelectListItem() { Value = x.Id.ToString(), Text = x.Title });
            });
        }
    }
}
