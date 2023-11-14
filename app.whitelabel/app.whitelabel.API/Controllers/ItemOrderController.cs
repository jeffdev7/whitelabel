using app.whitelabel.application.Services.Interfaces;
using app.whitelabel.application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace app.whitelabel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemOrderController : ControllerBase
    {
        private readonly IItemOrderServices _itemOrderServices;

        public ItemOrderController(IItemOrderServices itemOrderServices)
        {
            _itemOrderServices = itemOrderServices;
        }
        [HttpGet("itemOrders")]
        public IEnumerable<ItemOrderViewModel> GetAll()
        {
            return _itemOrderServices.GetItemOrders();
        }
    }
}