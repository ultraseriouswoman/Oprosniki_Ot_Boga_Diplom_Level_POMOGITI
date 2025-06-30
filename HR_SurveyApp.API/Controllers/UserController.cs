using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using HR_SurveyApp.Core.DTO;
using HR_SurveyApp.Core.ServiceContracts;
using HR_SurveyApp.Domain.RepositoryContracts;
using HR_SurveyApp.Web.Api.Models;
using System.Net;

namespace HR_SurveyApp.Web.Api.Controllers
{
    [Route("api/user/")]
    public class UserController(IUserService userService) : ApiController
    {
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<TokenResponse>>> Login([FromBody] LoginRequest request)
        {
            var response = new ApiResponse<TokenResponse>();
            var loginResponse = await userService.GetToken(request);
            response.Result = loginResponse;
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessages.Add("Username of password is incorrect");
                return BadRequest(response);
            }
            response.StatusCode = HttpStatusCode.OK;
            response.Result = loginResponse;
            return response;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> Register([FromBody] RegisterRequest request)
        {
            var response = new ApiResponse();
            bool isUserNameUnique = await userService.IsUniqueUser(request.Email);
            if (!isUserNameUnique)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessages.Add("Username is taken");
                return BadRequest(response);
            }
            var user = await userService.Register(request);
            if (user == null || string.IsNullOrEmpty(user.Id))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessages.Add("Too weak password!"); //TODO: Используй заглавные буквы, цифры в пароле
                return BadRequest(response);
            }
            response.StatusCode = HttpStatusCode.OK;
            return Ok(response);
        }
    }
}
