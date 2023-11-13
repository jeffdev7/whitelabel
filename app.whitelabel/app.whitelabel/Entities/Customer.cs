namespace app.whitelabel.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        //public string CEP { get; set; }
        public string Address { get; set; }
        public virtual List<Order> Orders { get; set; }

        public Customer(string name, string phoneNumber, string address, List<Order> orders)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Orders = orders;
        }
        public Customer(){}
    }
}