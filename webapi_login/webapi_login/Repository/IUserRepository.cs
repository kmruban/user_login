using System.Collections.Generic;
using webapi_login.Entities;

namespace webapi_login.Repository
{
	public interface IUserRepository
	{
		public IEnumerable<User> GetAll();

		public User GetUserByName(string name);

		public User GetUserById(string id);

		public User Login(string u, string p);

		public void InsertUser(User u);

		public void UpdateUser(string id, User u);

		public void DeleteUser(string id);
	}
}

