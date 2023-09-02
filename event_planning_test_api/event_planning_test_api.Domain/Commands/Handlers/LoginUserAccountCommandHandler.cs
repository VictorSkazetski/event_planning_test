using event_planning_test_api.Data.Dto;
using event_planning_test_api.Data.Entities;
using event_planning_test_api.Domain.Exceptions;
using event_planning_test_api.Domain.Interfaces;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace event_planning_test_api.Domain.Commands.Handlers
{
    public class LoginUserAccountCommandHandler :
        IRequestHandler<LoginUserAccountCommand, UserTokenDto>
    {
        private readonly UserManager<UserEntity> userManager;
        private readonly IMapper mapper;
        private readonly IJWTManager jWTManager;

        public LoginUserAccountCommandHandler(
            UserManager<UserEntity> userManager,
            IMapper mapper,
            IJWTManager jWTManager)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.jWTManager = jWTManager;
        }

        public async Task<UserTokenDto> Handle(
            LoginUserAccountCommand request,
            CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.UserEmail);
            if (user == default 
                || !await userManager.CheckPasswordAsync(user, request.UserPassword))
            {
                throw new UnauthorizedException("Не верный email или пароль");
            }
            else if (!await userManager.IsEmailConfirmedAsync(user))
            {
                throw new UnauthorizedException("Почта не подтверждена");
            }

            var token = await jWTManager.GenerateToken(user.Email);

            return mapper.Map<UserTokenDto>(token);
        }
    }
}
