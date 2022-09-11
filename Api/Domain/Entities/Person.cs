namespace Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        ICollection<Purchase> Purchase { get; set; }

        public Person(string name, string document, string phone)
        {
            Validation(name, document, phone);
        }

        public Person(int id, string name, string document, string phone)
        {
            Domain.Validations.DomainValidationException.When(id <= 0, "Id must be greater than zero");
            Id = id;
            Validation(name, document, phone);
        }

        private void Validation(string name, string document, string phone)
        {
            Domain.Validations.DomainValidationException.When(string.IsNullOrEmpty(name), "Name must be informed.");
            Domain.Validations.DomainValidationException.When(string.IsNullOrEmpty(document), "Document must be informed.");
            Domain.Validations.DomainValidationException.When(string.IsNullOrEmpty(phone), "Phone must be informed.");

            (Name, Document, Phone) = (name, document, phone);
        }
    }
}