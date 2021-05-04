using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reframe.Dal.Entities
{
    public partial class User : IdentityUser<int>
    {
        public User()
        {
            Subjects = new HashSet<Subject>();
            Courses = new HashSet<Course>();
            Places = new HashSet<Place>();
        }
        public string Name { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Place> Places { get; set; }
    }
}
