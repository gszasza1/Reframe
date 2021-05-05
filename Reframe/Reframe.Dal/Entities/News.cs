using System;
using System.Collections.Generic;
using System.Text;

namespace Reframe.Dal.Entities
{
   public  class News
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
    }
}
