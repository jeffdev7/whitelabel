using app.whitelabel.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace app.whitelabel.application.ViewModel
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}