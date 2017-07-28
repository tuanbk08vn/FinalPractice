﻿using DomainLayer.IRepository;
using DomainLayer.Models;
using Infracstructure.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Infracstructure.Repository
{
    class CategoryRepository : ICategoryRepository
    {
        private readonly MyContext _dbContext;

        public CategoryRepository(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> Get()
        {
            return _dbContext.Categories;
        }

        public bool Insert(Category category)
        {
            try
            {
                _dbContext.Categories.Add(category);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Update(Category category)
        {
            try
            {
                //var currentProduct = _dbContext.Products.Find(productId);
                var currentInDb = _dbContext.Categories.Find(category.Id);

                if (currentInDb != null)
                {
                    currentInDb = category;
                    _dbContext.Categories.AddOrUpdate(currentInDb);

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool Delete(int categoryId)
        {
            try
            {
                var category = _dbContext.Categories.Find(categoryId);
                if (category != null) _dbContext.Categories.Remove(category);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Category SelectOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
