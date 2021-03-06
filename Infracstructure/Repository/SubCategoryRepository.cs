﻿using DomainLayer.IRepository;
using DomainLayer.Models;
using Infracstructure.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Infracstructure.Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly MyContext _dbContext;

        public SubCategoryRepository(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SubCategory> Get()
        {

            return _dbContext.SubCategories.ToList();
        }

        public bool Insert(SubCategory subCategory)
        {
            try
            {
                _dbContext.SubCategories.Add(subCategory);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Update(SubCategory subCategory)
        {
            try
            {
                //var currentProduct = _dbContext.Products.Find(productId);
                var currentInDb = _dbContext.SubCategories.Find(subCategory.Id);

                if (currentInDb != null)
                {
                    currentInDb = subCategory;
                    _dbContext.SubCategories.AddOrUpdate(currentInDb);

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int subCategoryId)
        {
            try
            {
                var subCategory = _dbContext.SubCategories.Find(subCategoryId);
                if (subCategory != null) _dbContext.SubCategories.Remove(subCategory);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int GetByName(string name)
        {
            try
            {
                var resultInDb = _dbContext.SubCategories.FirstOrDefault(x => x.Name.ToLower().Contains(name));
                if (resultInDb != null)
                {
                    var result = resultInDb.Id;
                    return result;
                }

                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public SubCategory SelectOne(int id)
        {
            try
            {
                var result = _dbContext.SubCategories.FirstOrDefault(x => x.Id == id);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
