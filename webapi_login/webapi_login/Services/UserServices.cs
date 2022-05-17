using System.Collections.Generic;
using webapi_login.Entities;
using System.Collections;
using webapi_login.Repository;

namespace webapi_login.Services
{
	public class UserService : IUserServices
    {
        private IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> myList = _repo.GetAll();
            //sort list 
            return myList;
        }

        public User GetUserByName(string name)
        {
            return _repo.GetUserByName(name);
        }

        public User GetUserById(string id)
        {
            return _repo.GetUserById(id);
        }

        public User Login(string u, string p)
        {
            return _repo.Login(u, p);
        }

        public void CreateUser(User m)
        {
            _repo.InsertUser(m);
        }

        public void UpdateUser(string id, User m)
        {
            _repo.UpdateUser(id, m);
        }

        public void DeleteUser(string id)
        {
            _repo.DeleteUser(id);
        }


    }
}

