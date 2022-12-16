using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExamKpz.Models
{
    public class LawCase
    {
        [Required]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public List<Document> Documents { get; set; }
        [Required]
        public List<Comment> Comments { get; set; }
    }
}
