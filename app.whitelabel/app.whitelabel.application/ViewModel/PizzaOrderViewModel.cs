using app.whitelabel.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace app.whitelabel.application.ViewModel
{
    public class PizzaOrderViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsTwoFlavours { get; set; } = false;
        public int Quantity { get; set; }
        public decimal Subtotal { get; internal set; }
        public EPayment Payment { get; set; }
        public List<string> Flavours { get; set; }
    }
}
