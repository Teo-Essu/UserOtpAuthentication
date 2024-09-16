using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _service;
        public UserController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserAsync([FromBody] User user)
        {
            if (user is null)
                return BadRequest("User object is null");
                        
            var createdUser = _service.UserService.CreateUserAsync(user);

            using var httpClient = new HttpClient();
            string externalApiUrl = "https://8fb628917d6d.hstonline.tech/api/v1/sendSmsOtp";
            string jsonRequestBody = JsonSerializer.Serialize(new { phoneNumber = user.PhoneNumber });
            var requestBody = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

            // Add "Accept: application/json" header
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync(externalApiUrl, requestBody);

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<OtpResponse>(responseContent);

/*            var savedOtpResponse = _service.UserService.SaveOtp(responseObject);*/

            responseObject.data.otp.userId = (await createdUser).Id;

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, responseObject);

            return Ok(responseObject.data.otp);
        }

        [HttpPost("verifyOtp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtp verifyOtp)
        {
            if (verifyOtp is null)
                return BadRequest("Otp code is null");

           /* var requestId = _service.UserService.VerifyOtp(verifyOtp.requestId, verifyOtp.code, trackChanges: false).Result;*/

            using var httpClient = new HttpClient();
            string externalApiUrl = "https://8fb628917d6d.hstonline.tech/api/v1/verifySmsOtp";
            string jsonRequestBody = JsonSerializer.Serialize(new { code = verifyOtp.code, requestId = verifyOtp.requestId });
            var requestBody = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

            // Add "Accept: application/json" header
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync(externalApiUrl, requestBody);

            var responseContent = await response.Content.ReadAsStringAsync();
            var verifiedResponse = JsonSerializer.Deserialize<OtpResponse>(responseContent);

            if ((int)response.StatusCode == 404)
                return StatusCode((int)response.StatusCode, verifiedResponse);

            var tokenDto = await _service.AuthenticationService.CreateToken(verifyOtp.userId, populateExp: true);

            return Ok(tokenDto);
        }

        [HttpGet]/*
        [Authorize]*/
        public IActionResult GetAllUsers()
        {
            var users = _service.UserService.GetAllUsers(trackChanges: false);

            return Ok(users);
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     