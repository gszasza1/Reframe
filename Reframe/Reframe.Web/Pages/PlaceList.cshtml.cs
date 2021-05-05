using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reframe.Dal.Dto;
using Reframe.Dal.Services;

namespace Reframe.Web.Pages
{
    public class PlaceListModel : PageModel
    {
        public IEnumerable<PlaceListItem> PlaceList { get; set; }
        public async Task OnGetAsync(int id, [FromServices] PlaceService placeService)
        {
            PlaceList = await placeService.GetAllPlacesAsync();
        }
    }
}
