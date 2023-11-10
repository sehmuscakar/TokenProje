using ApiLayer.Core.Application.Dto;
using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Queries
{
    public class CheckUserQueryRequest:IRequest<CheckUserResponseDto> // bu interfaceyi geri döndürecek
    {
        public string UserName { get; set; } = null!; // default değeri boş olamaz

        public string Password { get; set; } = null!;
    }
}
