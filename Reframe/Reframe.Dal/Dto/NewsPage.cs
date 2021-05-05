using System;
using System.Collections.Generic;
using System.Text;

namespace Reframe.Dal.Dto
{
    public class NewsPage
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string Body { get; set; }
    }
}
