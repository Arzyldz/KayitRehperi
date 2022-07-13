namespace KayitRehperi.Core
{
    public class CustomerActivity: BaseEntity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
