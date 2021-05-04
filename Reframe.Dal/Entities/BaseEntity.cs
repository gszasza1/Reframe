using System;
using System.Collections.Generic;
using System.Text;

namespace Reframe.Dal.Entities
{
    public class BaseEntity
    {
        public bool isDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
