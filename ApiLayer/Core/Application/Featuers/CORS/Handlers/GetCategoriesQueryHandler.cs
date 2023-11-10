using ApiLayer.Core.Application.Dto;
using ApiLayer.Core.Application.Featuers.CORS.Queries;
using ApiLayer.Core.Application.Interfaces;
using ApiLayer.Core.Domain;
using AutoMapper;
using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this._repository.GetAllsync();
            return this._mapper.Map<List<CategoryListDto>>(data);
        }
    }
}
