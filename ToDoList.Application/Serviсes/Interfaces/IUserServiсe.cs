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
        public bool AddUser(UserDTO userDTO);
        public UserDTO GetUserById(int id);
        public UserDTO ChangeUser(UserDTO userDTO);
        public bool DeleteUserById(int id);

    }
}
