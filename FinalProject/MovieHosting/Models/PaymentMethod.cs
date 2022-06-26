using MovieHosting.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieHosting.Models
{
    public class PaymentMethod
    {
        [Key]
        public int IdPaymentMethod { get; set; }
        public PaymentType PaymentType { get; set; }

        [MinLength(5, ErrorMessage = "ReferenceNumber can't consist of less than 5 symbols")]
        public string ReferenceNumber { get; set; }
        public int IdClient { get; set; }

        public virtual Person ClientNavigation { get; set; }

    }

    
}