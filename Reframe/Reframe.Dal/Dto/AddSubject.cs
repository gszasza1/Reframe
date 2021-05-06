using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Reframe.Dal.Dto
{
    public class AddSubject
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [StringLength(200, MinimumLength = 10)]
        [Required]
        public string Description { get; set; }

        [Range(1, 30)]
        [Required]
        public int Credit { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
