using System;
using System.ComponentModel.DataAnnotations;

namespace MiniProject1
{
    class PaymentMethod
    {

        private static int id_counter = 0;
        private readonly int method_id;

        private PaymentType payment_type;
        private string reference_number;
        private Client client;
        
        [Required]
        [Key]
        public int MethodId { get { return method_id; } }

        public PaymentType PaymentType { get { return payment_type; } set { payment_type = value; } }

        [Required]
        public string ReferenceNumber 
        {
            get { return reference_number; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Provided value is null or empty");
            }
        }

        public Client Client 
        {
            get { return client; }
            set
            {
                if (client == value) return;

                if (client is not null)
                {
                    if (value is null)
                    {
                        // Remove connection
                        var tmp = client;
                        client = null;
                        tmp.RemovePaymentMethod(this);
                    }
                    else
                    {
                        // Change connection
                        var tmp = client;
                        client = null;
                        tmp.RemovePaymentMethod(this);
                        client = value;
                        value.AddPaymentMethod(this);
                    }
                }
                else
                {
                    if (value is not null)
                    {
                        // Create connection
                        client = value;
                        value.AddPaymentMethod(this);
                    }
                }

            }
        }

        public PaymentMethod(PaymentType payment_type, string reference_number)
        {
            method_id = id_counter;
            id_counter++;

            this.payment_type = payment_type;
            ReferenceNumber = reference_number;
        }

    }

    public enum PaymentType
    {
        CARD,
        BANK_ACCOUNT,
        MOBILE_PAY
    }
}
