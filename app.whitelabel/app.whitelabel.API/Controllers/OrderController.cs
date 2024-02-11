using app.whitelabel.application.Services.Interfaces;
using app.whitelabel.application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace app.whitelabel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet("orders")]
        public IEnumerable<OrderListViewModel> GetAll()
        {
            return _orderServices.GetOrders();
        }

        [HttpPost("new-order")]
        public async Task<ActionResult<OrderViewModel>> Add([FromBody] OrderViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var poll = await _orderServices.Add(vm);
            return Ok(poll);
        }
    }
}