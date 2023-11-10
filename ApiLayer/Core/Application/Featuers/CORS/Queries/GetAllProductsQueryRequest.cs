using ApiLayer.Core.Application.Dto;
using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Queries
{
    public class GetAllProductsQueryRequest:IRequest<List<ProductLİstDto>> // burasını dataacceslayer olarak düşün ,listeleme veb getbyıd için ama
    {

    }
}
