using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Reframe.Dal.Dto;
using Reframe.Dal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reframe.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IEnumerable<NewsBox> AllNews { get; set; }
        public async Task OnGetAsync([FromServices] NewService newsService)
        {
            AllNews = await newsService.GetAllNewsAsync();
        }
    }
}
