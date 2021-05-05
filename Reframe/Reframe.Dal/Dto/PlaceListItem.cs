using System;
using System.Collections.Generic;
using System.Text;

namespace Reframe.Dal.Dto
{
    public class PlaceListItem
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string Name { get; set; }
        public int NumberOfDesk { get; set; }
    }
}
