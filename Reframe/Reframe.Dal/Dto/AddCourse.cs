using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Reframe.Dal.Dto
{
    public class AddCourse
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Time { get; set; }

        [Required]
        public int PlaceId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
