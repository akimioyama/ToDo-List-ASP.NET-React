using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.DTO;

namespace ToDoList.Application.Serviсes.Interfaces
{
    public interface IUserServiсe
    {
        public UserDTO GetUserInfo(int id);
        public JwtDTO LoginUser(string login, string password);
        public JwtDTO RegisterUser(UserDTO userDTO);
    }
}
