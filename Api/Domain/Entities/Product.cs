namespace Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchase { get; set; }

        public Product(string name, string codErp, decimal price)
        {
            Validation(name, codErp, price);
        }

        public Product(int id, string name, string codErp, decimal price)
        {
            Domain.Validations.DomainValidationException.When(id <= 0, "Id must be greater than zero");
            Id = id;
            Validation(name, codErp, price);
        }

        private void Validation(string name, string codErp, decimal price)
        {
            Domain.Validations.DomainValidationException.When(string.IsNullOrEmpty(name), "Name must be informed.");
            Domain.Validations.DomainValidationException.When(string.IsNullOrEmpty(codErp), "cod Erp must be informed.");
            Domain.Validations.DomainValidationException.When(price <= 0, "Price must be greater than zero");

            (Name, CodErp, Price) = (name, codErp, price);
        }
    }
}