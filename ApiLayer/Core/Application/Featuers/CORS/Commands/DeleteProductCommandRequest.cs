using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Commands
{
    public class DeleteProductCommandRequest:IRequest
    {
        public int Id { get; set; }

        public DeleteProductCommandRequest(int id)
        {
            Id= id;
        }

    }
}
