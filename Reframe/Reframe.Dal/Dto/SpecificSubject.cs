using Reframe.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reframe.Dal.Dto
{
    public class SpecificSubject
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Credit { get; set; }
        public string Creator { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
