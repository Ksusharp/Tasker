using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tasker.DataModels
{
    public class Task
    {

        [Key]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string Term { get; set; }
        [MaxLength(100)]
        public string Status { get; set; }
    }
}
