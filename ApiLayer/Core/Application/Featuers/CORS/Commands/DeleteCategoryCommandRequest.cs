using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Commands
{
    public class DeleteCategoryCommandRequest:IRequest
    {
        public int Id { get; set; }
        public DeleteCategoryCommandRequest(int ıd)
        {
            Id = ıd;
        }
    }
}
