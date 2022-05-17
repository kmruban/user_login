using System;
namespace webapi_login.Entities
{
	public class User
	{
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            // string price = Price.ToString();
            return $"({Id}, {Username}, {Password}";
        }
    }
}

