
using JoinDev.Application.Commands;
using JoinDev.Domain.Core.Communication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JoinDev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediatorHandler _bus;

        public ValuesController(IMediatorHandler mediator)
        {
            _bus = mediator;
        }

        [HttpGet]
        public async Task GetTeste()
        {
            var command = new CreateUserCommand("joao", "j.c", "ola sou o", null, "jjsj@hotmail.com", "123456");

            var result = await _bus.SendCommand(command);
        }
    }
}
