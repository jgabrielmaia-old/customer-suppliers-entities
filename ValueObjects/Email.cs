namespace CompanySupplier.Entity.ValueObjects
{
    public class Email
    {
        public Email() { }

        public Email(string address)
        {
            Address = address;
        }

        public int Id { get; set; }

        public string Address { get; set; }

        public bool Validate()
        {
            var addr = new System.Net.Mail.MailAddress(Address);
            return addr.Address == Address;
        }
    }
}