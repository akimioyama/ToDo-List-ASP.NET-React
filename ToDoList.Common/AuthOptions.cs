using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Common
{
    public class AuthOptions
    {
        public string Issuer { get; set; }  // издатель токена
        public string Audience { get; set; } // потребитель токена
        public string KEY { get; set; }   // ключ для шифрации
        public int Lifetime { get; set; } // время жизни токена 
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
