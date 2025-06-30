using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HR_SurveyApp.Core.DTO;
using HR_SurveyApp.Domain.RepositoryContracts;
using HR_SurveyApp.Web.Api.Filters.ExceptionFilters;
using HR_SurveyApp.Web.Api.Models;

namespace HR_SurveyApp.Web.Api.Controllers
{
    [ApiController]
    [TypeFilter(typeof(ApiExceptionFilter))]
    public class ApiController : ControllerBase
    {
    }
}
