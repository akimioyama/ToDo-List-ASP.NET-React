using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.DTO;

namespace ToDoList.Application.Serviсes.Interfaces
{
    public interface ICategoryService
    {
        public CategoryDTO CreateCategoryByJwt(CategoryDTO categoryDTO, string jwt);
        public CategoryDTO CreateCategoryByUserId(CategoryDTO categoryDTO, int userId);
        public CategoryDTO ChangeCategory(CategoryDTO categoryDTO);
        public bool DeleteCategory(int id);
        public CategoryDTO GetCategory(int id);
        public List<CategoryDTO> GetCategotyListByUserId(int userId);
        public List<CategoryDTO> GetCategotyListByJwt(string jwt);
    }
}
