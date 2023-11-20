using app.whitelabel.Entities.Enum;

namespace app.whitelabel.Entities
{
    public class Pizza : BaseEntity
    {
        public EFlavour Flavour { get; set; }
        public decimal Price { get; set; }
        public bool TwoFlavours { get; set; }

        public Pizza(EFlavour flavour, decimal price, bool twoFlavours)
        {
            Flavour = flavour;
            Price = price;
            TwoFlavours = twoFlavours;
        }
        public Pizza(){}
    }
}