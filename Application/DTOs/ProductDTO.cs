using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatório")]
        [MaxLength(100)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        [MaxLength(100)]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        [DataType(DataType.Currency)]
        public string Price { get; set; }

        [MaxLength(250)]
        [DisplayName("Imagem")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Estoque é obrigatório")]
        [Range(1,9999)]
        [DisplayName("Estoque")]
        public int Stock { get; set; }

        public Category Category { get; set; }

        [DisplayName("Categorias")]
        public int CategoryId { get; set; }
    }
}
