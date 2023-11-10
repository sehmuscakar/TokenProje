using ApiLayer.Core.Application.Dto;
using ApiLayer.Core.Domain;
using AutoMapper;

namespace ApiLayer.Core.Application.Mappings
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}
