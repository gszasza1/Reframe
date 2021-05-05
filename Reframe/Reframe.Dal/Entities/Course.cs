using System;
using System.Collections.Generic;
using System.Text;

namespace Reframe.Dal.Entities
{
    public class Course
    {
        public DateTime CreationTime { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }
        public virtual Subject Subject { get; set; }
        public int SubjectId { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}
