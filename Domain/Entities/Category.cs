using Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Category : Entity
    {
        [MaxLength(50)]
        public string Name { get; private set; }
        public Category(string name)
        {
            ValidateCategory(name);
        }
        public Category(int idCategory, string name)
        {
            DomainExceptionValidation.When(idCategory < 0, "Id não pode ser menor do que");
            Id = idCategory;
            ValidateCategory(name);
        }

        public ICollection<Product> Products { get; private set; }
        private void Update(string name)
        {
            ValidateCategory(name);
        }
        private void ValidateCategory(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido, o campo é obrigatório");
            DomainExceptionValidation.When(name?.Length <3, "O tamtanho do nome não pode ser menor que 3");
            Name = name;
        }
    }
}
