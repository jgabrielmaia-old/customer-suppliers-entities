namespace CompanySupplier.Entity.ValueObjects
{
    public class FederativeUnit
    {
        private const int FederativeUnitLength = 2;

        public FederativeUnit() { }

        public FederativeUnit(string value)
        {
            Value = value;
        }

        public int Id { get; set; }

        public string Value { get; set; }

        public bool Validate() => Value.Length == FederativeUnitLength;

    }
}