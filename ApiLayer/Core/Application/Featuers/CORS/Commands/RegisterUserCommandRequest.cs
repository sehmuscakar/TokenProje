using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Commands
{
    public class RegisterUserCommandRequest:IRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }

    }
}
