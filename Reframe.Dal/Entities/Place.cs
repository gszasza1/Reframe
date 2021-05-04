using System;
using System.Collections.Generic;
using System.Text;

namespace Reframe.Dal.Entities
{
    public class Place : BaseEntity
    {
        public Place()
        {
            Courses = new HashSet<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int  NumberOfDesk { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }

    }
}
