using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesService.Models
{
    class Types
    {
        [Key]
        public int ID { set; get; }
        [Required]
        public string Name { get; set; }
    }
}