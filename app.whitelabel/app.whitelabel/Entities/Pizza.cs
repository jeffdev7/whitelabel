using app.whitelabel.Entities.Enum;

namespace app.whitelabel.Entities
{
    public class Pizza : BaseEntity
    {
        public EFlavour Flavour { get; set; }
        public decimal Price { get; set; }

        public Pizza(EFlavour flavour, decimal price)
        {
            Flavour = flavour;
            Price = price;

        }

        public Pizza() { }
    }
}