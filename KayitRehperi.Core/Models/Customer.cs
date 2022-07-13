namespace KayitRehperi.Core
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EMail { get; set; }
        public string Tel { get; set; }
        public string City { get; set; }

        public byte[] Image { get; set; }
        public ICollection<CustomerActivity> CustomerActivities { get; set; }
    }
}
