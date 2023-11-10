using ApiLayer.Core.Application.Featuers.CORS.Commands;
using ApiLayer.Core.Application.Featuers.CORS.Queries;
using ApiLayer.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;
        [HttpPost("Register")] // burdaki actionu alır actionda yazsan gene registerı alır
        public async  Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await this.mediator.Send(request);

            return Created("",request);
        }
        [HttpPost("[action]")] // buna login de yazsan farketmiyor
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var dto=await this.mediator.Send(request);
            if (dto.IsExist)
            {
                return Created("", JwtTokenGenerator.GenereateToken(dto));
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatali");
            }
        }
    }
}
