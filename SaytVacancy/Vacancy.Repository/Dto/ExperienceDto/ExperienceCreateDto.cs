using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy.Repository.Dto.ExperienceDto
{
    public class ExperienceCreateDto
    {
        public int ExperienceId { get; set; }
        public string? ExperienceName { get; set; }
    }
} 
