using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using HR_SurveyApp.Core.DTO;

namespace HR_SurveyApp.UI.Models
{
    public class SurveyViewModel
    {
        [ValidateNever]
        public SurveyResponse? Survey { get; set; }
        public SubmissionCreateRequest Request { get; set; }
    }
}
