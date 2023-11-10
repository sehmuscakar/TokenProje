using ApiLayer.Core.Application.Enums;
using ApiLayer.Core.Application.Featuers.CORS.Commands;
using ApiLayer.Core.Application.Interfaces;
using ApiLayer.Core.Domain;
using MediatR;

namespace ApiLayer.Core.Application.Featuers.CORS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;

        public RegisterUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await this._repository.CreateAsync(new AppUser
            {
                Password = request.Password,
                UserName = request.UserName,
                AppRoleId = (int)RoleType.Member,
            }) ; //await yazdığında asaync otomatik yyazılıyor zatne 

            return Unit.Value;
        }
    }
}
