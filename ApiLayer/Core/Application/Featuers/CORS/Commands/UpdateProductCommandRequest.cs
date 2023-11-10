using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Commands
{
    public class UpdateProductCommandRequest:IRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
