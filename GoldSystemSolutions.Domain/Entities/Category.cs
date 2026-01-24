using GoldSystemSolutions.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{

    //Entidade de categoria, onde serão armazenadas as categorias dos produtos.
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ICollection<Product> Products { get; set; } //PROPERTY NAVIGATION

        public Category(
            String name,
            String description
            )
        {
            ValidationDomain(name, description);
        }

        public Category(int id, String name, String description)
        {
            DomainExceptionValidation.When(Id < 0,
                "Invalid Id. Id must be greater than or equal to zero");
            Id = id;
            ValidationDomain(name, description);    
        }

        public void Update(
            String name,
            String description
            )
        {
            ValidationDomain(name, description);
        }

        
        private void ValidationDomain(
            String name,
            String description
            )
        {
            //Validações das propriedades da entidade Category
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid Name. Name is required");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Name, too short, minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid Description. Description is required");
            DomainExceptionValidation.When(description.Length < 5,
                "Invalid Description, too short, minimum 5 characters");
            DomainExceptionValidation.When(description.Length > 200,
                "Invalid Description, too long, maximum 200 characters");
            DomainExceptionValidation.When(name.Length > 100,
                "Invalid Name, too long, maximum 100 characters");

            Name = name;
            Description = description;

        }

    }
}
