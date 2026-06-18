using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Category : ICategory
    {
        private readonly Idb _db;
        public Category(Idb db)
        {
            _db = db;
        }

        public void AddCategory(CategoriesDTO category)
        {
            var user = _db.GetAllUsers().FirstOrDefault(x => int.Parse(x.UserId) == category.UserCode);
            if (user != null)
            {
                List<CategoriesDTO> categories = _db.GetCategory(user);
                if (categories.Any(c => c.CategoryName == category.CategoryName))
                {
                    throw new Exception("Category name already exists for this user.");
                }
                if(categories.Any(c => c.Color == category.Color))
                {
                    throw new Exception("Category color already exists for this user.");
                }
                _db.AddCategory(category);
            }
            throw new Exception("User not found.");

        }

        public void DeleteCategory(CategoriesDTO category)
        {
            var user = _db.GetAllUsers().FirstOrDefault(x => int.Parse(x.UserId) == category.UserCode);
            if (user != null)
            {
                if(_db.GetCategory(user).Any(c => c.CategoryId == category.CategoryId))
                {
                    _db.DeleteCategory(category);
                }
                else
                {
                    throw new Exception("Category not found for this user.");
                }
            }
            throw new Exception("User not found.");

        }

        public List<CategoriesDTO> GetCategory(UsersDTO user)
        {
            var categories = _db.GetCategory(user);
            if (categories == null || categories.Count == 0)
            {
                throw new Exception("No categories found for this user.");
            }
            return categories;
        }

        public void UpdateCategory(CategoriesDTO category)
        {
            var user = _db.GetAllUsers().FirstOrDefault(x => int.Parse(x.UserId) == category.UserCode);
            if (user != null)
            {
                if(_db.GetCategory(user).Any(c => c.CategoryId == category.CategoryId))
                {
                    _db.UpdateCategory(category);
                }
                else
                {
                    throw new Exception("Category not found for this user.");
                }
                if (_db.GetCategory(user).Any(c => c.Color == category.Color))
                {
                    throw new Exception("Category color already exists for this user.");
                }
            }
            throw new Exception("User not found.");

        }
    }
}
