namespace TimeExchangePlatform.Models
{
    public class Exchange
    {
        public int Id { get; set; }
        public int Hours { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public ExchangeStatus Status { get; set; } = ExchangeStatus.Pending;
        // Fk to Offer
        public int OfferId { get; set; }
        public Offer Offer { get; set; } = null!;
        
        public int ProviderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public User Provider { get; set; } = null!;
        public User Receiver { get; set; } = null!;

    }
    public enum ExchangeStatus
    {
        Pending,
        Accepted,
        Completed,
        Cancelled
    }
}
