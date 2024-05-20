using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProgramlama.EfCore
{
    [Table("customer")]
    public class Customer
    {
        [Key, Required]
        public int CustomerId { get; set; }
        public string Customerusername { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
