using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTesting.Models;

namespace WebTesting.Service
{
    public interface IProductService
    {
        IEnumerable<Products> GetList();
        bool Create(Products model);
    }

    public class ProductService : IProductService
    {
        private readonly TestingDbContext _context;

        public ProductService(TestingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Products> GetList()
        {
            var listProducts = new List<Products>();
            try
            {
                listProducts = _context.Productos.ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return listProducts;
        }

        public bool Create(Products model)
        {
            bool created = false;

            try
            {
                _context.Entry(model).State = EntityState.Added;
                _context.SaveChanges();
                created = true;
            }
            catch (Exception)
            {
                created = false;
            }
            return created;
        }
    }
}
