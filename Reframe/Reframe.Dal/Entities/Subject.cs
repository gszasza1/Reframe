using System;
using System.Collections.Generic;

namespace Reframe.Dal.Entities
{
    public class Subject
    {
        public Subject()
        {
            Courses = new HashSet<Course>();
        }
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Credit { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
