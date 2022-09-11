namespace Domain.Entities
{
    public sealed class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; private set; }
        public Product Product { get; private set; }

        public Purchase(int produtcId, int personId, DateTime? date)
        {
            Validation(produtcId, personId, date);
        }

        public Purchase(int id, int produtcId, int personId, DateTime? date)
        {
            Domain.Validations.DomainValidationException.When(id <= 0, "Id must be greater than zero");
            Id = id;
            Validation(produtcId, personId, date);
        }

        private void Validation(int produtcId, int personId, DateTime? date)
        {
            Domain.Validations.DomainValidationException.When(produtcId <= 0, "Product Id must be informed.");
            Domain.Validations.DomainValidationException.When(personId <= 0, "Person Id must be informed.");
            Domain.Validations.DomainValidationException.When(!date.HasValue, "The date must be informed");

            (ProductId, PersonId, Date) = (produtcId, personId, date.Value);
        }
    }
}
