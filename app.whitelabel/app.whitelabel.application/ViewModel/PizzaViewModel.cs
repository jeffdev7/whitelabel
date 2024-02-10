using app.whitelabel.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace app.whitelabel.application.ViewModel
{
    public class PizzaViewModelList
    {
        [Key]
        public Guid Id { get; set; }
        public EFlavour Flavour { get; set; }
        public decimal Price { get; set; }
    }
    public class PizzaViewModel
    {
        [Key]
        public EFlavour Flavour { get; set; }
        public decimal Price { get; set; }
    }
}