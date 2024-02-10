using app.whitelabel.Entities.Enum;

namespace app.whitelabel.Entities
{
    public class ItemOrder : BaseEntity
    {
        public List<Pizza> Pizzas { get; set; }
        public virtual Order Order { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public EPayment Payment { get; set; }
        public bool IsTwoFlavours { get; set; } = false;
        public decimal Subtotal
        {
            get
            {
                if (Pizzas != null && Pizzas.Count > 0 && Pizzas[0] != null)
                {
                    if (IsTwoFlavours == true && Pizzas.Count > 1 && Pizzas.Count == 2 && Pizzas[0] != null)
                    {
                        return (Pizzas[0].Price / 2) + (Pizzas[1].Price / 2) * Quantity;
                    }
                    else
                        return (decimal)(Quantity * Pizzas[0].Price);

                }
                else
                    return 0;

            }
        }

        public ItemOrder(List<Pizza> pizzas, Order order, Guid orderId,
            int quantity, EPayment payment, bool isTwoFlavours)
        {
            Pizzas = pizzas;
            Order = order;
            OrderId = orderId;
            Quantity = quantity;
            Payment = payment;
            IsTwoFlavours = isTwoFlavours;
        }

        public ItemOrder() { }
    }
}