using System;
using System.Collections.Generic;
using System.Text;

namespace Reframe.Dal.Dto
{
    public class AddSubject
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Credit { get; set; }
        public int UserId { get; set; }
    }
}
