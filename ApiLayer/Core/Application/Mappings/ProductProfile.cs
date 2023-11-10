using ApiLayer.Core.Application.Dto;
using ApiLayer.Core.Application.Featuers.CORS.Handlers;
using ApiLayer.Core.Domain;
using AutoMapper;

namespace ApiLayer.Core.Application.Mappings
{
    public class ProductProfile:Profile //auto maper kütüphanesiniden yararlandık 
    {
        // ctor
        public ProductProfile()
        {
            this.CreateMap<Product,ProductLİstDto>().ReverseMap();// product yerine ProductListDto yu tanıtık ve tam terside tabi bunu bide program.cs te tanıtman lazım 
        }
    }
}
