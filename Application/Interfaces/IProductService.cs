using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetallProducts();
        Task<ProductDto> GetByIdProduct(int? id);

        Task AddProduct(ProductDto dto);
        Task UpdateProduct(ProductDto dto);
        Task RemoveProduct(int? id);
    }
}
