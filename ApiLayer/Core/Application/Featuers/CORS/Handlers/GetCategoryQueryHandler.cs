using ApiLayer.Core.Application.Dto;
using ApiLayer.Core.Application.Featuers.CORS.Queries;
using ApiLayer.Core.Application.Interfaces;
using ApiLayer.Core.Domain;
using AutoMapper;
using MediatR;
using System.ComponentModel;

namespace ApiLayer.Core.Application.Featuers.CORS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto?>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;
        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoryListDto?> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var result=await this.repository.GetByFilterAsync(x=>x.Id==request.Id);
            return this.mapper.Map<CategoryListDto>(result);
        }
    }
}
