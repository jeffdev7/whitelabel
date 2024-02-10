using System.ComponentModel.DataAnnotations;

namespace app.whitelabel.application.ViewModel
{
    public class OrderViewModel
    {
        [Key]
        public Guid CustomerId { get; set; }
        public List<ItemOrderViewModel> Items { get; set; }
    }
    public class OrderListViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public List<ItemOrderViewModel> Items { get; set; }
    }
}