﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_SurveyApp.Core.DTO
{
    public class SurveyReplaceRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<QuestionCreateRequest> Questions { get; set; }
    }
}
