using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExamKpz.Models
{
    public class Comment
    {
        [Required]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Content { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(30)]
        public string Author { get; set; }

    }
}
