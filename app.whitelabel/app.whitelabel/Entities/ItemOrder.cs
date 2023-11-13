using app.whitelabel.Entities.Enum;

namespace app.whitelabel.Entities
{
    public class ItemOrder : BaseEntity
    {
        public virtual Pizza Pizza { get; set; }
        public Guid PizzaId { get; set; }
        public virtual Order Order { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => Quantity * UnitPrice;
        public EPayment Payment { get; set; }

        public ItemOrder(Pizza pizza, Guid pizzaId, Order order, Guid orderId, int quantity, decimal unitPrice, EPayment payment)
        {
            Pizza = pizza;
            PizzaId = pizzaId;
            Order = order;
            OrderId = orderId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Payment = payment;
        }
        public ItemOrder() {}
    }
}