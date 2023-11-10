using ApiLayer.Core.Application.Dto;
using ApiLayer.Core.Application.Featuers.CORS.Queries;
using ApiLayer.Core.Application.Interfaces;
using ApiLayer.Core.Domain;
using AutoMapper;
using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ProductLİstDto>
    {
        private readonly IRepository<Product> _repository; //birden fazla constractır uygulamak istersen hepsini seç ona göre 
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductLİstDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this._repository.GetByFilterAsync(x => x.Id == request.Id);
            return this._mapper.Map<ProductLİstDto>(data);
        }
    }
}
