using System.Collections.Generic;
using CompanySupplier.Entity.Enums;
using CompanySupplier.Entity.ValueObjects;

namespace CompanySupplier.Entity.Model
{
    public class Supplier
    {
        public Supplier() { }

        public Supplier(string name, Email email, Document document)
        {
            Name = name;
            Email = email;
            Document = document;
        }

        public int SupplierId { get; private set; }

        public string Name { get; private set; }

        public Email Email { get; private set; }

        public Document Document { get; private set; }

        public ICollection<CompanySupplier> CompanySuppliers { get; private set; }

        public bool Validate() => !string.IsNullOrWhiteSpace(Name);

        public bool AddEmail(string address)
        {
            var email = new Email(address);
            if (!email.Validate())
                return false;

            Email = email;
            return true;
        }

        public bool AddDocument(string value, int type)
        {
            var document = new Document(value, (EDocumentType) type);

            if (!document.Validate())
                return false;

            Document = document;
            return true;
        }
    }
}