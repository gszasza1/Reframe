using System;
using System.Collections.Generic;
using System.Text;

namespace Reframe.Dal.Entities
{
    public class Place
    {
        public Place()
        {
            Courses = new HashSet<Course>();
        }
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string Name { get; set; }
        public int  NumberOfDesk { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}
