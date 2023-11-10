using ApiLayer.Core.Application.Dto;
using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Queries
{
    public class GetCategoriesQueryRequest:IRequest<List<CategoryListDto>>
    {

    }
}
