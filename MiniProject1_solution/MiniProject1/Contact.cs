using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject1
{
    [Serializable]
    [ComplexType]
    class Contact
    {
        private string email;
        private string phone;

        public string Email
        {
            get { return email; }
            set 
            {
                if (value == null || value.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. Field email is mandatory!");
                else email = value;
            }
        }
        public string Phone 
        {
            get { return phone; }
            set
            {
                if (value == null || value.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. Field phone is mandatory!");
                else if (value.Trim().Length < 8) throw new ArgumentException("Provided string is too short for the mobile number");
                else phone = value;
            }
        }

        //constructor
        public Contact(string email, string phone)
        {
            if (email == null || email.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. Field email is mandatory!");
            if (phone == null || phone.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. Field phone is mandatory!");
            else if (phone.Trim().Length < 8) throw new ArgumentException("Provided string is too short for the mobile number");

            this.email = email;
            this.phone = phone;
        }

        public override string ToString()
        {
            return $"{this.GetType()} [email: {email}; phone: {phone}]";
        }
    }
}
