namespace app.whitelabel.Entities
{
    public class Order : BaseEntity
    {
        public virtual Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public List<ItemOrder> Items { get; set; }

        public Order(Customer customer, Guid customerId, List<ItemOrder> items)
        {
            Customer = customer;
            CustomerId = customerId;
            Items = items;
        }
        public Order(){}
    }
}