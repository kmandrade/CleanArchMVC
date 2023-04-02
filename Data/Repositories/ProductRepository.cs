using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductReposiroty
    {
        private readonly DbSet<Product> _dbSet;
        public ProductRepository(MyContext _context):base(_context)
        {
            _dbSet = _context.Set<Product>();
        }
    }
}
