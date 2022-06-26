namespace MiniProject5.Models
{
    class ClientMovie
    {
        public int IdClient { get; set; }
        public int IdMovie { get; set; }
        public virtual Client ClientNavigation { get; set; }
        public virtual Movie MovieNavigation { get; set; }
    }
}