using System;

namespace MovieHosting.Models
{
    public class AdminMovie
    {
        public int IdAdmin { get; set; }
        public int IdMovie { get; set; }
        public virtual Person AdminNavigation { get; set; }
        public virtual Movie MovieNavigation { get; set; }
    }
}