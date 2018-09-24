using LHBOL;
using LHDAL;
using System;
using System.Collections.Generic;

namespace LHBLL
{
    public interface ICategoryBs
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        bool Create(Category category);
        bool Update(Category category);
        bool Delete(int id);
    }

    public class CategoryBs : ICategoryBs
    {
        //CategoryDb CategoryDb;
        ICategoryDb CategoryDb;
        public CategoryBs(ICategoryDb categoryDb)
        {
            CategoryDb = categoryDb;
        }

        public bool Create(Category category)
        {
            return CategoryDb.Create(category);
        }

        public bool Delete(int id)
        {
            return CategoryDb.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = CategoryDb.GetAll();
            return categories;
        }

        public Category GetById(int id)
        {
            var category = CategoryDb.GetById(id);
            return category;
        }

        public bool Update(Category category)
        {
            return CategoryDb.Update(category);
        }
    }
}
