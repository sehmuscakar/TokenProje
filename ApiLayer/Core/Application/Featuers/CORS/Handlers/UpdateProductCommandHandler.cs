using ApiLayer.Core.Application.Featuers.CORS.Commands;
using ApiLayer.Core.Application.Interfaces;
using ApiLayer.Core.Domain;
using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Handlers
{
    public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommandRequest> // burasıı manager olarak düşün 
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedPrroduct = await this._repository.GetByIdAsync(request.Id);
            if (updatedPrroduct == null)
            {
                updatedPrroduct.CategoryId = request.CategoryId;
                updatedPrroduct.Stock = request.Stock;
                updatedPrroduct.Price = request.Price;
                updatedPrroduct.Name = request.Name;
                await this._repository.UpdateAsync(updatedPrroduct);
            }

            return Unit.Value;
        }
    }
}
