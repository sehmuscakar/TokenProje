using ApiLayer.Core.Application.Dto;
using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Queries
{
    public class GetCategoryQueryRequest:IRequest<CategoryListDto?> // burda getbıd görevini yapacak
    {
        public int Id { get; set; }

        public GetCategoryQueryRequest(int ıd)
        {
            Id = ıd;
        }

     
    }
}
