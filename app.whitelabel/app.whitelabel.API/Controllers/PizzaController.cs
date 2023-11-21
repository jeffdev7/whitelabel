using app.whitelabel.application.Services.Interfaces;
using app.whitelabel.application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace app.whitelabel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaServices _pizzaServices;

        public PizzaController(IPizzaServices pizzaServices)
        {
            _pizzaServices = pizzaServices;
        }

        [HttpGet("pizzas")]
        public IEnumerable<PizzaViewModelList> GetAll()
        {
            return _pizzaServices.GetPizzas();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _pizzaServices.Remove(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpPost("add-pizza")]
        public async Task<ActionResult<PizzaViewModel>> Add([FromBody] PizzaViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var poll = await _pizzaServices.Add(vm);
            return Ok(poll);
        }
    }
}