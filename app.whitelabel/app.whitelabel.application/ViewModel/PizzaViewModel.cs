using app.whitelabel.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace app.whitelabel.application.ViewModel
{
    public class PizzaViewModel
    {
        [Key]
        public Guid Id {get;set;}
        public EFlavour Flavour { get; set; }
        public decimal Price { get; set; }
    }
}