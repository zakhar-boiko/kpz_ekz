using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExamKpz.Models
{
    public class Document
    {
        [Required]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Link { get; set; }

    }
}
