using System;

namespace MovieHosting.Models
{
    public class ClientMovie
    {
        public int IdClient { get; set; }
        public int IdMovie { get; set; }
        public DateTime PurchaseDate { get; set; }

        public virtual Person ClientNavigation { get; set; }
        public virtual Movie MovieNavigation { get; set; }
    }
}