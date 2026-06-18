using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICategory
    {
        public List<CategoriesDTO> GetCategory(UsersDTO user);
        public void AddCategory(CategoriesDTO category);
        public void UpdateCategory(CategoriesDTO category);
        public void DeleteCategory(CategoriesDTO category);
    }
}
