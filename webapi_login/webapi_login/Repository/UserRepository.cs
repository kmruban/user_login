using System.Collections.Generic;
using webapi_login.Entities;
using MySql.Data.MySqlClient;
using System;

namespace webapi_login.Repository
{
	public class UserRepository : IUserRepository
	{
        private MySqlConnection _connection;
        public UserRepository()
        {
            string connectionString = "server=localhost;userid=root;password=kyleruban;database=website_database";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }
        ~UserRepository()
        {
            _connection.Close();
        }

        public IEnumerable<User> GetAll()
        {
            var statement = "Select * from Users";
            var command = new MySqlCommand(statement, _connection);
            var results = command.ExecuteReader();

            List<User> newList = new List<User>(1000);
            while (results.Read())
            {
                User m = new User
                {
                    Id = (int)results[0],
                    Username = (string)results[1],
                    Password = (string)results[2]
                };
                newList.Add(m);

            }
            results.Close();
            return newList;
        }

        public User GetUserByName(string name)
        {
            var statement = "Select * from Users where Username = @newName ";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newName", name);

            var results = command.ExecuteReader();
            User m = null;
            if (results.Read())
            {
                m = new User
                {
                    Id = (int)results[0],
                    Username = (string)results[1],
                    Password = (string)results[2]
                };
            }
            results.Close();
            return m;
        }

        public User GetUserById(string id)
        {
            var statement = "Select * from Users where user_id = @id ";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@id", id);

            var results = command.ExecuteReader();
            User m = null;
            if (results.Read())
            {
                m = new User
                {
                    Id = (int)results[0],
                    Username = (string)results[1],
                    Password = (string)results[2]
                };
            }
            results.Close();
            return m;
        }

        public User Login(string username, string password)
        {
            var statement = "SELECT * FROM Users WHERE Password = @enteredPassword && Username = @enteredUsername";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@enteredUsername", username);
            command.Parameters.AddWithValue("@enteredPassword", password);

            var results = command.ExecuteReader();
            User m = null;
            if (results.Read())
            {
                m = new User
                {
                    Id = (int)results[0],
                    Username = (string)results[1],
                    Password = (string)results[2]
                };
            }
            results.Close();
            return m;
        }

        public void InsertUser(User m)
        {
            var statement = "Insert into Users (Username, Password) Values(@n,@p)";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@n", m.Username);
            command.Parameters.AddWithValue("@p", m.Password);

            int result = command.ExecuteNonQuery();

            Console.WriteLine(result);

        }

        public void UpdateUser(string id, User userIn)
        {
            var statement = "Update Users Set Username=@updateUsername, Password=@updatePwd Where user_id=@userid";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@updateUsername", userIn.Username);
            command.Parameters.AddWithValue("@updatePwd", userIn.Password);
            command.Parameters.AddWithValue("@userid", id);

            int result = command.ExecuteNonQuery();
        }

        public void DeleteUser(string id)
        {
            var statement = "DELETE FROM Users Where user_id=@deleteId";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@deleteId", id);

            int result = command.ExecuteNonQuery();
        }



    }
}

