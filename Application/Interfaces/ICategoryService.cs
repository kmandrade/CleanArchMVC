using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetallCategories();
        Task<CategoryDto> GetByIdCategory(int? id);

        Task AddCategory(CategoryDto dto);
        Task UpdateCategory(CategoryDto dto);
        Task RemoveCategory(int? id);
    }
}
