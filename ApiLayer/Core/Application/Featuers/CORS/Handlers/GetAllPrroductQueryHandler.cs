using ApiLayer.Core.Application.Dto;
using ApiLayer.Core.Application.Featuers.CORS.Queries;
using ApiLayer.Core.Application.Interfaces;
using ApiLayer.Core.Domain;
using AutoMapper;
using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Handlers
{
    public class GetAllPrroductQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<ProductLİstDto>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        public GetAllPrroductQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<List<ProductLİstDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this._repository.GetAllsync();
            return this._mapper.Map<List<ProductLİstDto>>(data); // içindeki datayı productlistdto ya çevir ve dataya aktar anlamında
        }
    }
}
