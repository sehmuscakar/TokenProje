using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Commands
{
    public class CreateCategoryCommandRequest:IRequest
    {
        public string? Definition { get; set; }
    }
}
