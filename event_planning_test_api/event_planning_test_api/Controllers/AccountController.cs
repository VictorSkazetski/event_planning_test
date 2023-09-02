using event_planning_test_api.Domain.Commands;
using event_planning_test_api.Data.Dto;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using event_planning_test_api.App.Routes;

namespace event_planning_test_api.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IMediator Mediator;

        public AccountController(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        [HttpPost(RouteParts.AccountRegistration)]
        public async Task<AccountDto> Create([FromBody] AccountData command)
        {
            return await Mediator.Send(
                new CreateUserAccountCommand()
                {
                    UserEmail = command.UserEmail,
                    UserPassword = command.UserPassword,
                });
        }

        [HttpPost(RouteParts.AccountVerify)]
        public async Task<UserEmailVerifyDto> VerifyUserEmail(
            [FromBody] EmailVerifyTokenData command)
        {
            return await Mediator.Send(
                new VerifyUserAccountEmailCommand()
                {
                    UserEmail = command.UserEmail,
                    Token = command.Token,
                });
        }

        [HttpPost(RouteParts.Accountlogin)]
        public async Task<UserTokenDto> Login([FromBody] AccountData command)
        {
            return await Mediator.Send(
                new LoginUserAccountCommand() 
                { 
                    UserEmail = command.UserEmail,
                    UserPassword = command.UserPassword,
                });
        }
    }
}
