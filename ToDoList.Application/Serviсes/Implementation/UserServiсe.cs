﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.DTO;
using ToDoList.Application.Serviсes.Interfaces;
using ToDoList.EntityFramework.Repository.Interfaces;
using ToDoList.EntityFramework.Repository.Implementation;
using ToDoList.Domain;
using Microsoft.Extensions.Configuration;
using ToDoList.Common;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ToDoList.Application.Serviсes.Implementation
{
    public class UserServiсe : IUserServiсe
    {
        IConfiguration _configuration;
        public UserServiсe(IConfiguration conf)
        {
            _configuration = conf;
        }
        public AuthOptions authOp { get; }
        public UserDTO GetUserInfo(int id)
        {
            IUserSelects userSelects = new UserSelects();
            User user = userSelects.GetUserById(id);
            UserDTO userDTO = new UserDTO()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                Fio = user.Fio
            };
            return userDTO;
        }

       public JwtDTO LoginUser(string login, string password)
       {
            try
            {
                IUserSelects userSelects = new UserSelects();
                int? userId = userSelects.FindUserByLoginAndPassword(login, password);
                if (userId != null)
                {
                    return GetJwtDTOById(userId);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
       }
       public JwtDTO RegisterUser(UserDTO userDTO)
       {
            try
            {
                User user = new User()
                {
                    Login = userDTO.Login,
                    Password = userDTO.Password,
                    Email = userDTO.Email,
                    Fio = userDTO.Fio
                };
                IUserSelects userSelects = new UserSelects();

                if (userSelects.CreateUser(user))
                {
                    int? userId = userSelects.FindUserByLoginAndPassword(userDTO.Login, userDTO.Password);
                    if(userId != null)
                    {
                        CategorySelects categorySelects = new CategorySelects();
                        Category category = new Category()
                        {
                            Name = "Без категории",
                            UserId = userId.Value
                        };
                        categorySelects.CreateCategory(category);
                        return GetJwtDTOById(userId);
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
       }

        private JwtDTO GetJwtDTOById(int? id)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid", id.ToString())
                };
                ClaimsIdentity claimsIdentity = 
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                var autOp = _configuration.GetSection("Auth").Get<AuthOptions>();
                var now = DateTime.UtcNow;
                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                        issuer: autOp.Issuer,
                        audience: autOp.Audience,
                        notBefore: now,
                        claims: claimsIdentity.Claims,
                        expires: now.Add(TimeSpan.FromMinutes(autOp.Lifetime)),
                        signingCredentials: new SigningCredentials(autOp.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                JwtDTO response = new JwtDTO()
                {
                    access_token = encodedJwt,
                    username = claimsIdentity.Name
                };

                return response;
            }
            catch
            {
                return null;
            }
        }


        private string GetUserIdFromJwt(string jwtString)
        {
            try
            {
                bool isValid = ValidateToken(jwtString);
                if (isValid)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(jwtString);
                    var tokenS = (JwtSecurityToken)jsonToken;

                    var id = tokenS.Claims.
                        Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid").
                        Select(claim => claim.Value).FirstOrDefault();
                    return id;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        private bool ValidateToken(string authToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationParameters();

                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
                return true;
            }
            catch
            {
                return false;
            }

        }
        private TokenValidationParameters GetValidationParameters()
        {
            var autOp = _configuration.GetSection("Auth").Get<AuthOptions>();

            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = authOp.Issuer,
                ValidateAudience = true,
                ValidAudience = authOp.Audience,
                ValidateLifetime = true,
                IssuerSigningKey = authOp.GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true,
            };
        }
    }
}
