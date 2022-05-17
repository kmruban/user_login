using System.Collections.Generic;
using webapi_login.Entities;
using System.Collections;
using webapi_login.Repository;

namespace webapi_login.Services
{
    public interface IUserServices
    {
        public IEnumerable<User> GetUsers();

        public User GetUserByName(string name);

        public User GetUserById(string id);

        public User Login(string u, string p);

        public void CreateUser(User p);

        public void UpdateUser(string id, User p);

        public void DeleteUser(string id);
    }

}