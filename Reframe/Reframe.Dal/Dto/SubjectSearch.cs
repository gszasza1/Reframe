using System;
using System.Collections.Generic;
using System.Text;

namespace Reframe.Dal.Dto
{
   public class SubjectSearch
    {
        public int Id { get; set; }
        public string SearchText { get; set; }
        public string Credit { get; set; }
        public bool IsAsc { get; set; }
        public int Page { get; set; } = 0;
    }
}
