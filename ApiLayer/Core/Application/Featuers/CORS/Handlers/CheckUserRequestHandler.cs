using ApiLayer.Core.Application.Dto;
using ApiLayer.Core.Application.Featuers.CORS.Queries;
using ApiLayer.Core.Application.Interfaces;
using ApiLayer.Core.Domain;
using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Handlers
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> userRepository;
        private readonly IRepository<AppRole> roleRepository;

        public CheckUserRequestHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
           var  dto=new CheckUserResponseDto();

            var user = await this.userRepository.GetByFilterAsync(x => x.UserName == request.UserName && x.Password == request.Password);
            if (user==null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.UserName = user.UserName;
                dto.Id=user.Id;
                dto.IsExist = true;
                var role=await this.roleRepository.GetByFilterAsync(x=>x.Id==user.AppRoleId);
                dto.Role = role?.Definition;
            }
            return dto;
        }
    }
}
