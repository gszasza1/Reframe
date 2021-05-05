using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ganss.XSS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reframe.Dal.Dto;
using Reframe.Dal.Services;

namespace Reframe.Web.Pages
{
    public class AddNewsModel : PageModel
    {
        private readonly NewService _newsService;
        public AddNewsModel(NewService newsService)
        {
            _newsService = newsService;
        }
        [BindProperty]
        public PostNews PostNews { get; set; }
        public void OnGet()
        {
        }
        public void OnPostAddNews()
        {
            var sanitizer = new HtmlSanitizer();
            PostNews.Body = sanitizer.Sanitize(PostNews.Body);
            _newsService.AddNews(PostNews);

        }
    }
}
