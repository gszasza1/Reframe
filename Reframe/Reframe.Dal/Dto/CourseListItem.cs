using System;

namespace Reframe.Dal.Dto
{
    public class CourseListItem
    {
        public DateTime CreationTime { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public string PlaceName  { get; set; }
        public string SubjectName { get; set; }
        public string Creator { get; set; }
    }
}
