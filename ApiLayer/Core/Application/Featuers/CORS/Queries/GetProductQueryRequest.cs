using ApiLayer.Core.Application.Dto;
using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Queries
{
    public class GetProductQueryRequest:IRequest<ProductLİstDto>
    {
        public int Id { get; set; }

        public GetProductQueryRequest(int ıd) // burdaki pparetre den bana ıd değer gelsin
        {
            Id = ıd; // yukardaki ıd değerini setyiyeyim
        }
    }
}
