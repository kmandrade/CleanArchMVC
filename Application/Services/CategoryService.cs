using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetallCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdCategory(int? id)
        {
            var categorie = await _categoryRepository.GetIdAsync((int)id);
            return _mapper.Map<CategoryDto>(categorie);
        }
        public async Task AddCategory(CategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _categoryRepository.CreateAsync(category);
        }
        public async Task RemoveCategory(int? id)
        {
            var category = _categoryRepository.GetIdAsync((int)id).Result;
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task UpdateCategory(CategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
