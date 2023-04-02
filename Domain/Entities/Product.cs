using Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Product : Entity
    {
        [MaxLength(50)]
        public string Name { get; private set; }

        [MaxLength(50)]
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateProduct(name, description, price, stock, image);
        }
        public Product(int idProduct, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(idProduct < 0, "IdProduto inválido, id precisa ser passado");
            ValidateProduct(name, description, price, stock, image);
            Id = idProduct;
        }
        public int IdCategory { get; set; }
        public Category Category { get; set; }

        private void UpdateProduct(string name, string description, decimal price, int stock, string image, int idCategory)
        {
            ValidateProduct(name, description, price, stock, image);
            IdCategory = idCategory;
        }
        private void ValidateProduct(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido, o campo é obrigatório");
            DomainExceptionValidation.When(name?.Length < 3, "O tamtanho do nome não pode ser menor que 3");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Nome inválido, o campo é obrigatório");
            DomainExceptionValidation.When(description?.Length < 6, "O tamtanho do nome não pode ser menor que 3");

            DomainExceptionValidation.When(price < 0, "Id não pode ser menor do que");

            DomainExceptionValidation.When(stock < 0, "Id não pode ser menor do que");

            DomainExceptionValidation.When(image?.Length > 250, "O tamtanho do nome não pode ser menor que 3");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

    }
}
