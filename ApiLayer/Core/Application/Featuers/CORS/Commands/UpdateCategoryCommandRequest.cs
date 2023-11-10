using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Commands
{
    public class UpdateCategoryCommandRequest:IRequest
    {
        public int Id { get; set; }

        public string? Definition { get; set; }
    }
}
