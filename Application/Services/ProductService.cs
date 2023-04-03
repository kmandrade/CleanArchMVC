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
    public class ProductService : IProductService
    {
        private readonly IProductReposiroty _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductReposiroty productReposiroty, IMapper mapper)
        {
            _productRepository = productReposiroty;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetallProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdProduct(int? id)
        {
            var product = await _productRepository.GetIdAsync((int)id);
            return _mapper.Map<ProductDto>(product);
        }
        public async Task AddProduct(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productRepository.CreateAsync(product);
        }
        public async Task RemoveProduct(int? id)
        {
            var product = _productRepository.GetIdAsync((int)id).Result;
            await _productRepository.DeleteAsync(product);
        }

        public async Task UpdateProduct(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productRepository.UpdateAsync(product);
        }
    }
}
