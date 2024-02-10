using app.whitelabel.application.Services.Interfaces;
using app.whitelabel.application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace app.whitelabel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet("customers")]
        public async Task<IEnumerable<CustomerViewModelList>> GetAll()
        {
            return _customerServices.GetCustomers();
        }

        [HttpPost("add-customer")]
        public async Task<ActionResult<CustomerViewModel>> Add([FromBody] CustomerViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var poll = await _customerServices.Add(vm);
            return Ok(poll);
        }
    }
}