using System;
using System.Collections.Generic;
using CompanySupplier.Entity.Enums;
using CompanySupplier.Entity.ValueObjects;

namespace CompanySupplier.Entity.Model
{
    public class Company
    {
        public Company() { }

        public Company(string fantasyName)
        {
            FantasyName = fantasyName;
        }

        public int CompanyId { get; set; }

        public string FantasyName { get; private set; }

        public Document Document { get; private set; }

        public FederativeUnit FederativeUnit { get; private set; }

        public ICollection<CompanySupplier> CompanySuppliers { get; private set; }

        public bool Validate() => !string.IsNullOrWhiteSpace(FantasyName);

        public bool AddDocument(string value, EDocumentType type)
        {
            var document = new Document(value, type);
            
            if (document.Type != EDocumentType.Cnpj)
                return false;

            if (!document.Validate())
                return false;

            Document = document;
            return true;
        }

        public bool AddFederativeUnit(string stateAbbreviation)
        {
            var federativeUnit = new FederativeUnit(stateAbbreviation);
            if (!federativeUnit.Validate())
                return false;

            FederativeUnit = federativeUnit;
            return true;
        }
    }
}