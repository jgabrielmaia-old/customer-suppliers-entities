namespace CompanySupplier.Entity.Model
{
    public class CompanySupplier
    {
        public int CompanyId { get; private set; }

        public Company Company { get; private set; }

        public int SupplierId { get; private set; }

        public Supplier Supplier { get; private set; }
    }
}
