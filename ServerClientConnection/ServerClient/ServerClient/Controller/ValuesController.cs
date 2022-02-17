using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ServerClient.Business;
using ServerClient.Hubs;
using System.Threading.Tasks;

namespace ServerClient.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MyBusiness _myBusiness;
        private readonly IHubContext<MyHub> _hubContext;

        public ValuesController(MyBusiness myBusiness, IHubContext<MyHub> hubContext)
        {
            _myBusiness = myBusiness;
            _hubContext = hubContext;
        }
        [HttpGet("{message}")]
        public async Task<IActionResult> Index(string message)
        {
            await _myBusiness.SendMessageAsync(message);
            return Ok();
        }
    }
}
