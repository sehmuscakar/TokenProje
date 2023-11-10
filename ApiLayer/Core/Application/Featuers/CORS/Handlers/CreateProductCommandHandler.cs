using ApiLayer.Core.Application.Featuers.CORS.Commands;
using ApiLayer.Core.Application.Interfaces;
using ApiLayer.Core.Domain;
using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Handlers
{
    public class CreateProductCommandHandler:IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await this._repository.CreateAsync(new Product
            {
                CategoryId= request.CategoryId,
                Name= request.Name, 
                Price= request.Price,
                Stock= request.Stock,
            });

            return Unit.Value;  
        }
    }
}
