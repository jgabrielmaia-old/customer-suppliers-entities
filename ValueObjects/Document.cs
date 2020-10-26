using CompanySupplier.Entity.Enums;

namespace CompanySupplier.Entity.ValueObjects
{
    public class Document
    {
        private const int CnpjLength = 14;
        private const int CpfLength = 11;

        public Document() {  }

        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;
        }

        public int Id { get; set; }

        public string Number { get; set; }

        public EDocumentType Type { get; set; }

        public bool Validate()
        {
            if (Type == EDocumentType.Cnpj && Number.Length == CnpjLength)
                return true;

            if (Type == EDocumentType.Cpf && Number.Length == CpfLength)
                return true;

            return false;
        }
    }
}